    public class HomeController : Controller
    {
        private readonly IConstantHelper _constantHelper;
        public HomeController(IConstantHelper constantHelper)
        {
            _constantHelper = constantHelper;
        }
        public ActionResult Index()
        {
            return View(_constantHelper.ConstantForLog);
        }
    }
