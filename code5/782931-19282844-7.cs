    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            MyVM vm = new MyVM();
            return View(vm);   //you will have FooDdl available in your views
        }
    }
