    public class HomeController : Controller
    {
        public ActionResult Blah(int someParam)
        {
            // do something
            return RedirectToAction("SomeOtherAction", "SomeOther");
        }
    }
    
    public class SomeOtherController : Controller
    {
        public ActionResult SomeOtherAction()
        {
            // and do something here
            return View();
        }
    }    
