    using System.Web.Mvc;
    
        namespace Jmp.StaticMeasures.Controllers
        {
            public class ErrorController : Controller
            {
                public ActionResult Index()
                {
                    return View();
                }
        
                public ActionResult NotFound()
                {
                    return View();
                }
        
                public ActionResult NotAuthorised()
                {
                    return View();
                }
        
            }
        }
