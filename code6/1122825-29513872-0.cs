    public class AllowAnonymousOnly : AuthorizeAttribute
    {    
    	protected override bool AuthorizeCore(HttpContextBase httpContext)
    	{
    		// make sure the user is not authenticated. If it's not, return true. Otherwise, return false
    	}
    }
