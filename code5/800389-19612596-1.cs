        public class IpCheckFilter : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (filterContext.HttpContext.Request.ServerVariables["REMOTE_HOST"] != "ValidIP")
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "controller", "Home" }, { "action", "Index" } });
            }
        }
        [IpCheckFilter]
        public class HomeController : AdminBaseController
        {
             public HomeController() : base()
             {            
             }
        }
       
