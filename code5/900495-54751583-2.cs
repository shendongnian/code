    [Authorize]
    [CustomHeaders]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
