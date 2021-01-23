    public class HomeController : Controller
    {
        [LogActionFilter]
        public ActionResult Index()
        {
            return View();
        }
    }
    
    public class LogActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // If you register globally, you need this check.
            if (!filterContext.IsChildAction)
            {
               Log("OnActionExecuting", filterContext.RouteData);
            }
            base.OnActionExecuting(filterContext);
        }
    
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // If you register globally, you need this check.
            if (!filterContext.IsChildAction)
            {
               Log("OnActionExecuted", filterContext.RouteData);
            }
            base.OnActionExecuted(filterContext);
        }
    
        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName);
            Debug.WriteLine(message, "Action Filter Log");
        }
    }
