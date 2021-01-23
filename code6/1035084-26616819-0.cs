    public class Authorise : AuthorizeAttribute
    {
    	private readonly string _permissionSystemName;
    
    	public Authorise()
    	{
    	}
    
    	public Authorise(string permissionSystemName)
    	{
    		_permissionSystemName = permissionSystemName;
    	}
    
    	protected override bool AuthorizeCore(HttpContextBase httpContext)
    	{
    		//DO some logic and return True or False based on whether they are allowed or not.
    		
    		return false;
    	}
    
    	protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    	{
    		filterContext.Result = new RedirectToRouteResult(
    			new RouteValueDictionary(
    				new
    				{
    					area = filterContext.HttpContext.Request.RequestContext.RouteData.Values["area"],
    					controller = "Generic",
    					action = "PermissionDenied"
    				})
    			);
    	}
    }
