    public class HomeController : Controller
    {
        BasicViewModel model;
        public HomeController()
        {
            model = new BasicViewModel();
            model.Page = new Page();
            model.Settings = new List<Settings>();
        }
    
        public ActionResult Index()
        {
            model.Page.PageName = "My Page";
            ViewBag.LayoutModel = model;
            return View();
        }
     }
