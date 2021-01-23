    public class HomeController : Controller
    {
        private IMember _member;
        public HomeController(IMember member)
        {
            _member = member;
        }
        public ActionResult Index()
        {
            return View(_member);
        }
    }
