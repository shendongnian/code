    using System.Web.Mvc;
    using WebApplication4.Models;
    
    namespace WebApplication4.Controllers
    {
        public class Default1Controller : Controller
        {
            public ActionResult Index()
            {
                var ob = new Customer
                {
                    Id = 1001, 
                    CustomerCode = "C001", 
                    Amount = 900.23
                };
    
                return View(ob);
            }
        }
    }
