    public class WebApiAuthorizeAttribute : AuthorizeAttribute
    {
    	public override async Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
    	{
    		base.OnAuthorization(actionContext);
    
    		Guid userId;
    
    		if (actionContext.RequestContext.Principal.Identity.IsAuthenticated
    			&& Guid.TryParse(actionContext.RequestContext.Principal.Identity.GetUserId(), out userId))
    		{
    			ApplicationUserManager manager = new ApplicationUserManager(new ApplicationUserStore(new ApplicationDbContext())) { PasswordHasher = new CustomPasswordHasher() };
    
    			ApplicationUser user = await manager.FindByIdAsync(userId);
    			
    			actionContext.Request.Properties.Add("MyCustomId", user.MyCustomId);
    		}
    	}
    }
