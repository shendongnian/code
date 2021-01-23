    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using RustyLazyLoadTester.Mobile.Services;
    using RustyLazyLoadTester.Mobile.Services.Models;
 
    namespace RustyLazyLoadTester.Mobile.Controllers
    {
    public class HomeController : Controller
    {
        private readonly IQueryService _query;
        public HomeController()
        {
            _query = new QueryService();
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetNextUsers(UserStatus status, int limit, int fromRowNumber)
        {
            try
            {
                var users = _query.GetAllUsers(status, limit, fromRowNumber);
 
                if (!users.Any())
                    return Json(string.Empty);
 
                return PartialView("_UserList", users);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(ex.Message);
            }
        }
    }
    }
