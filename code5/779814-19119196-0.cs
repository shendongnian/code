    namespace MyNamespace.Controllers
    {
        public class MyControllerBase : Controller
        {
            public bool Check(string actionName, ControllerBase controllerBase)
            {
                ControllerContext controllerContext = new ControllerContext(this.ControllerContext.RequestContext, controllerBase);
                return false;
            }
        }
        public class MyControllerA : MyControllerBase
        {
            ActionResult Index()
            {
                bool b = base.Check("Index", this);
                return View();
            }
        }
        public class MyControllerB : MyControllerBase
        {
            ActionResult Index()
            {
                bool b = base.Check("Index", this);
                return View();
            }
        }
    }
