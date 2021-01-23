    public class TestController : Controller
    {
        private readonly ITestApplicationService service;
    
        public TestController (ITestApplicationService service)
        {
            this.service = service;
        }
    
        public ActionResult Index(SomeFilter filter)
        {
            var viewModelList = service.GetModelList(filter, Url);
            return View(viewModelList);
        }
    	...
    }
