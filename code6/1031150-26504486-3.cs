    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult One()
        {
            return PartialView();
        }
        public PartialViewResult Two()
        {
            return PartialView();
        }
    }
   
