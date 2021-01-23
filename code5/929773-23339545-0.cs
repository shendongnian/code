    public class BaseController : Controller
    {
        public virtual ActionResult News()
        {
            return PartialView("_MyPartial");
        }
    }
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
