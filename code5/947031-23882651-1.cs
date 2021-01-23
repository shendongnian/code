    [MyFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TempData["key"] = "some_value";
            return View();
        }
    }
