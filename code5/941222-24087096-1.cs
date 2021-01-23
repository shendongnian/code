    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    {
    	
    	if (filterContext.HttpContext.User.Identity.IsAuthenticated)
    		throw new HttpException((int)HttpStatusCode.Forbidden, "Unauthorized access");
    	
    	base.HandleUnauthorizedRequest(filterContext);
    }
