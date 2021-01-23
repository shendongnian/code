    public class PropertyController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Step1()
        {
            ViewBag.Hello = "Hello";
            return PartialView("_Partial1", ViewBag.Hello);
        }
	}
