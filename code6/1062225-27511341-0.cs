    public class ClientRequiredAttribute : ActionFilterAttribute
    {
    	public override void OnActionExecuting(ActionExecutingContext filterContext)
    	{
    		object parameter = null;
    		filterContext.ActionParameters.TryGetValue("client", out parameter);
    		var client = parameter as string;
    		
    		if (string.IsNullOrEmpty(client))
    		{
    			var urlHelper = new UrlHelper(filterContext.Controller.ControllerContext.RequestContext);
    		
    			var url = urlHelper.Action("Select", "ControllerName");
    
    			filterContext.Result = new RedirectResult(url);
    		}
    	}
    }
