    public class LogOnAuthoRization: AuthorizeAttribute
    {     
    	public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
    	{
    		var isAuthorised = base.IsAuthorized(actionContext);
    
    		if (isAuthorised)
    		{
    			var cookie = HttpContext.Current.Request.Cookies
    			[FormsAuthentication.FormsCookieName];
    			var ticket = FormsAuthentication.Decrypt(cookie.Value);
    			var identity = new GenericIdentity(ticket.Name);
    			string userData = ticket.UserData;
    			if (userData.Contains("_"))
    			{
    				string[] data = userData.Split('_');
    				if (data != null && data.Length > 3)
    				{
    					string Email = data[0];
    					string Id = data[1];
    					string FullName = data[2];
    					string Role = data[3];
    					var principal = new CustomUserPrincipal
    					(identity, new Guid(Id), Email, Role, FullName);
    					HttpContext.Current.User = principal;
    					Thread.CurrentPrincipal = principal;
    				}
    			}
    		}
    	}
    } 
