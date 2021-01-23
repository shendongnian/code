    public class TestController : Controller
    {
        public ActionResult Index()
        {
            throw new Exception("oops");
            return View();
        }
    }
