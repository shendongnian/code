    public class MyController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.MyVal = 9;
            return Index();
        }
    }
