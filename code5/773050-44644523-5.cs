    [AuthenticationFilter(Order = 1)]
    public class HomeController : Controller
    {
        [LoggerActionFilter(Order = 2)]
        public ActionResult UserLandingPage()
        {
            return View();
        }
    }
    [AuthenticationFilter(Order = 1)]
    public class AdminController : Controller
    {
        [LoggerActionFilter(Order = 2)]
        public ActionResult CreateUser()
        {
            return View();
        }
    }
    [AuthenticationFilter(Order = 1)]
    public class ReportController : Controller
    {
        [LoggerActionFilter(Order = 2)]
        public ActionResult AppUtilization()
        {
            return View();
        }
    }
