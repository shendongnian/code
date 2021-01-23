    public class HomeController : Controller
    {
        public static Story Story1 = new Story("Test title", "Test author");
        public ActionResult Index()
        {
            return View(Story1);
        }
        public ActionResult Action2()
        {
            return View(Story1);
        }
        public ActionResult ActionN()
        {
            return View(Story1);
        }
    }
