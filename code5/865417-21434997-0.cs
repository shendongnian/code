    public class HomeController : Controller
    {
        private IUserManager<ApplicationUser> userManager;
        public HomeController(IUserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public ActionResult Index()
        {
            var user = "user";
            var password = "password";
            var result = userManager.CreateAsync(user, password);
            return View();
        }
    }
