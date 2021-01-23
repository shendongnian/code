    public class ApiAuthentication : AuthorizeAttribute
    {
      protected override bool IsAuthorized(HttpActionContext context)
      {
           //Your Authentication Logic Here for example:
           //context.Request.Headers.TryGetValues("Authorization", out buffers);
      }
    }
    
    protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
    {
          //this method is for handling Unauthorized Request
    }
