    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int Version = (int)HttpContext.Application["Version"];
            return View();
        }
    }
