    public class ErrorController : Controller
    {   
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult General()
        {            
            return RedirectToAction("Index", "Error");
        }
        public ActionResult Http404()
        {
            return View();
        }
        public ActionResult Http403()
        {
            return View();
        }
    }
