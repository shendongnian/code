    public class RedirectFilterAttribute : ActionFilterAttribute
    {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
    			// get the home controller in a safe cast
                var homeController = filterContext.Controller as Controller;
     
    			// check if it is home controller and not Result action
    			if (homeController != null && filterContext.ActionDescriptor.ActionName != "Result")
                {
                    if (homeController.IsFinish())
                    {
    					filterContext.Result = new RedirectToRouteResult(
    						new RouteValueDictionary 
    						{ 
    							{ "controller", "Home" }, 
    							{ "action", "Result" } 
    						});
                    }
                }
    
                base.OnActionExecuting(filterContext);
            }
    }
