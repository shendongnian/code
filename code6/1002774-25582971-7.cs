    public HomeController : Controller {
        [HttpGet]
        public ActionResult Index() {
            var example = new Example(new Service());
            example.SomeFunc();
            // .. the rest ..
        }
    }
