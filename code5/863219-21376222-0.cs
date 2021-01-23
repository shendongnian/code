        public class DemoController : Controller
        {
            public ActionResult Index()
            {
                return View();
            }
    
            [HttpGet]
            public ActionResult CallMe()
            {
                return new ContentResult() { Content = "This is Demo " };
            }
    }
