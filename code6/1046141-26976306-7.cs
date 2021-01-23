    public class MvcAuthorizeAttribute : AuthorizeAttribute
    {
    	public override void OnAuthorization(AuthorizationContext filterContext)
    	{
    		base.OnAuthorization(filterContext);
    
    		if (HttpContext.Current.User.Identity.IsAuthenticated)
    		{
    			var userId = new Guid(HttpContext.Current.User.Identity.GetUserId());
    
    			ApplicationUserManager manager =
    				new ApplicationUserManager(new ApplicationUserStore(new ApplicationDbContext()))
    				{
    					PasswordHasher = new CustomPasswordHasher()
    				};
    
    			var user = manager.FindById(userId);
    			
    			actionContext.Request.Properties.Add("MyCustomId", user.MyCustomId);			
    		}
    		else
    		{
    			filterContext.Result = new HttpUnauthorizedResult();
    		}
    	}
    }
