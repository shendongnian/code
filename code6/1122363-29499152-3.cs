	public class MyActionFilter : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
            // use the extension method in your filter
        	if (filterContext.HasAttribute(typeof(AllowAnonymousAttribute)))
			{
                // exit early...
				return;
			}
            // ...or do whatever else you need to do
            if (user == null || !user.Active)
            {
			    filterContext.Result = 
                    new RedirectToRouteResult(new RouteValueDictionary
			    {
			        { "controller", "Home" }, 
			        { "action", "NotAuthorized" }
			    });
            }
			base.OnActionExecuting(filterContext);
		}
	}
