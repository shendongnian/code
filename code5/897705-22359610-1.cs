    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel();
            return View(model);
        }
    
        [HttpPost]
        public ActionResult Index(MyViewModel myViewModel)
        {
            var z = myViewModel.Z;
            return null;
        }
    }
