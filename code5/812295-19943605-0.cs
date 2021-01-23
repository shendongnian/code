    public class TestController : Controller
    {
        public ActionResult Index()
        {
            return View(new TestModel());
        }
        [HttpPost]
        public ActionResult Index(TestModel model)
        {
            return View(model);
        }
    }
