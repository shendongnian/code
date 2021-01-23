    public class AuthorizeAttributeExtended : AuthorizeAttribute
    {
    	protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
    	{
    		var tokenHasExpired = false;
    		var owinContext = OwinHttpRequestMessageExtensions.GetOwinContext(actionContext.Request);
    		if (owinContext != null)
    		{
    			tokenHasExpired = owinContext.Environment.ContainsKey("oauth.token_expired");
    		}
    
    		if (tokenHasExpired)
    		{
    			actionContext.Response = new AuthenticationFailureMessage("unauthorized", actionContext.Request,
    				new
    				{
    					error = "invalid_token",
    					error_message = "The Token has expired"
    				});
    		}
    		else
    		{
    			actionContext.Response = new AuthenticationFailureMessage("unauthorized", actionContext.Request,
    				new
    				{
    					error = "invalid_request",
    					error_message = "The Token is invalid"
    				});
    		}
    	}
    }
    
    public class AuthenticationFailureMessage : HttpResponseMessage
    {
    	public AuthenticationFailureMessage(string reasonPhrase, HttpRequestMessage request, object responseMessage)
    		: base(HttpStatusCode.Unauthorized)
    	{
    		MediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();
    
    		Content = new ObjectContent<object>(responseMessage, jsonFormatter);
    		RequestMessage = request;
    		ReasonPhrase = reasonPhrase;
    	}
    }
