    namespace stackoverflow.Controllers
    {
        public class HomeController : Controller
        { 
           public ActionResult PostFile(HttpPostedFileBase myFile)
           {
                System.Diagnostics.Debugger.Break();
                return View();
           } 
        }
    } 
