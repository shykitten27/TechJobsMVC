using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view. 
        public IActionResult Results(string searchType, string searchTerm) 
        {
            var column = searchType;
            var value = searchTerm;
            List<Job> jobs;
            if (column.ToLower().Equals("all")) //check column aka searchType
            {
                if (value == null || value == "") //check value aka searchTerm
                {
                    value = "all"; //set the searchTerm to "all"
                    jobs = JobData.FindAll();
                    ViewBag.title = "All Jobs";
                }
                else //column searchType is "all", but value searchTerm is filled
                {
                    jobs = JobData.FindByColumnAndValue(column, value);
                    ViewBag.title = "Jobs with " + column + ": " + value;
                }
            }
            else //column searchType is filled
            {
                if (value == null || value == "") //check value aka searchTerm
                {
                    value = "all"; //set the searchTerm to "all"
                    jobs = JobData.FindByColumnAndValue(column, value);
                    ViewBag.title = "Jobs with " + column + ": " + value;
                }
                else //column searchType is filled and value searchTerm is filled
                {
                    jobs = JobData.FindByColumnAndValue(column, value);
                    ViewBag.title = "Jobs with " + column + ": " + value;
                }
            }
            ViewBag.jobs = jobs;
            ViewBag.columns = ListController.ColumnChoices; //using list controller inside of the search controller
            ViewBag.searchTerm = searchTerm;
            return View("Index");
        }
    }
}
