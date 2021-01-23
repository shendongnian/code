    public class DashboardController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.User = WorkContext.CurrentUser;
            return View();
        }
    }
