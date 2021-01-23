    public class HomeController : Controller
    {
        [LoggerActionFilter(Order = 1)]
        public ActionResult UserLandingPage()
        {
            return View();
        }
    }
    
    public class AdminController : Controller
    {
        [LoggerActionFilter(Order = 1)]
        public ActionResult CreateUser()
        {
            return View();
        }
    }
    
    public class ReportController : Controller
    {
        [LoggerActionFilter(Order = 1)]
        public ActionResult AppUtilization()
        {
            return View();
        }
    }
