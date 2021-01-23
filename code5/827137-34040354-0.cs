    public class PropertyController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Step1()
        {
            TempData["Hello"] = "Hello";
            return PartialView();
        }
    }
