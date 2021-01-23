    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index( string FirstName, string LastName )
        {
            return View();
        }
    }
