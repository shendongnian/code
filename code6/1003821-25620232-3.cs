    public class AuthenticationHandler : DelegatingHandler
    {		
    	protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    	{
    		try
    		{
    			var queryString = actionContext.Request.RequestUri.Query;
    			var items = HttpUtility.ParseQueryString(queryString);
    			var userId = items["uid"];
    			
    			// Here check your UID and maybe some token, just dummy logic
    			if (userId == "D8CD2165-52C0-41E1-937F-054F24266B65")
    			{			
    				IPrincipal principal = new UidPrincipal(new UidIdentity(uid), null);
    
    				// HttpContext exist only when hosting as asp.net web application in IIS or IISExpress
    				if (HttpContext.Current != null)
    				{
    					HttpContext.Current.User = principal;
    				}
    				else
    				{
    					Thread.CurrentPrincipal = principal;
    				}
    				return base.SendAsync(request, cancellationToken);
    			}
    			catch (Exception ex)
    			{
    				this.Log().Warn(ex.ToString());
    				return this.SendUnauthorizedResponse(ex.Message);
    			}
    		}
    		else
    		{
    			return this.SendUnauthorizedResponse();
    		}
    		}
    		catch (SecurityTokenValidationException)
    		{
    			return this.SendUnauthorizedResponse();
    		}
    	}
    }
