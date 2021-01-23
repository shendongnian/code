    public class BlackboxAuthorizeAttribute : AuthorizeAttribute
    {
     protected override bool AuthorizeCore(HttpContextBase httpContext)
     {
     //write here custom authorization logic
     }
     protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
     {
    
     }
    }
