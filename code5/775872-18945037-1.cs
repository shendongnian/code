    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string username = User.Identity.Name;
            SomeUserModel user = GetUserFromBackend(username);
            return View(user);
        }
    }
