	public class MyActionFilter : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
        	if (HasAttribute(filterContext, typeof(AllowAnonymousAttribute)))
			{
				return;
			}
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
		private bool HasAttribute(ActionExecutingContext filterContext, Type attribute)
		{
			var actionDesc = filterContext.ActionDescriptor;
			var controllerDesc = actionDesc.ControllerDescriptor;
			
			bool allowAnon = 
				actionDesc.IsDefined(attribute, true) ||
				controllerDesc.IsDefined(attribute, true);
			
			return allowAnon;
		}
	}
