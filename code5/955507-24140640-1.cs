    public class TestController : Controller
        {
            private ITestService service;
            public TestController(ITestService service)
            {
                this.service = service;
            }
            // GET: Test
            [HttpGet]
            public ActionResult Index()
            {
                var test = new TestModel();
                test.Greeting = "yo";
                test.Name = "nils";
                return View(test);
            }
        }
