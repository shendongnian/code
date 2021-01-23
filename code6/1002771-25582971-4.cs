    public class HomeController : Controller {
        private readonly IExample _example;
        public HomeController(IExample example) {
            _example = example;
        }
        [HttpGet]
        public ActionResult Index() {
            _example.SomeFunc();
            // .. the rest ..
        }
    }
