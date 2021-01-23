	public class MyActionFilter : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			bool allowAnon = 
				filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
				filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);
			
        	if (allowAnon)
			{
				return;
			}
			
			filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
			{
			    { "controller", "Home" }, 
			    { "action", "NotAuthorized" }
			});
			base.OnActionExecuting(filterContext);
		}
	}
