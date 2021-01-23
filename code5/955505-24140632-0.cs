    public class TestController : Controller
    {
        private readonly ITestService service;
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
            // TODO do something with ITestService
            // this.service.DoSomethingCool()
    
            return View(test);
        } 
}
