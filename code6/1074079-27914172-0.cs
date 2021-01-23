    public class HomeController : Controller {
        public HomeController(IMyAppBusinessLogic bll) { ... }
    }
    public class WebApiController : Controller {
        public WebApiController(IMyAppBusinessLogic bll) { ... }
    }
    public class MyAppBusinessLogic : IMyAppBusinessLogic {
        public MyAppBusinessLogic(ITodoRepository repository) { ... }
    }
