    [AuthenticateUser]
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
    
        [CustomOverrideAuthenticateUser]
        public ActionResult List()
        {
            return View();
        }
    }
