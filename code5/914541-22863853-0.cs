    [Authorize(Roles = "Admin, AnotherRole")]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
