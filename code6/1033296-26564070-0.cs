    public class HomeController : Controller
    {
        private readonly ITest test;
    
        public HomeController(ITest test)
        {
            this.test = this;
        }
       
        public ActionResult Index()
        {
            //use test here
            return View();
        }
    }
