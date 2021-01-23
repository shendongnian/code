    public class MyAuthorizeAttribute : AuthorizeAttribute 
    {
    	public override async Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
    	{
    		if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()) return;
    
    		base.OnAuthorization(actionContext);
    
    		Guid userId;
    
    		if (actionContext.RequestContext.Principal.Identity.IsAuthenticated
    			&& Guid.TryParse(actionContext.RequestContext.Principal.Identity.GetUserId(), out userId))
    		{
    			actionContext.Request.Properties.Add("userId", actionContext.RequestContext.Principal.Identity.GetUserId());
    		}
    	}
    }
