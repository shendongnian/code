    public class MyFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
			var controllerName = routeData.Values["controller"];
			var actionName = routeData.Values["action"];
			
            foreach(var kvp in filterContext.ActionParameters)
                //log your params
        }
    }
