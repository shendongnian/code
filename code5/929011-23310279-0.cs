    public class ExtendedAuthorizeAttribute : AuthorizeAttribute
    {
    	protected string permission;
    	protected string group;
    	
    	public ExtendedAuthorizeAttribute(string Permission, string Group)
    	{
    		permission = Permission;
    		group = Group;
    	}
    
    	protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
    	{
    		var can = PermissionManager.Can(httpContext.User, permission, group);
    		if(can.HasValue)
    			return can.Value;
    		return base.AuthorizeCore(httpContext);
    	}
    }
