    public class CustomAutorizeAttribute : AuthorizeAttribute
    {
       protected override bool AuthorizeCore(HttpContextBase httpContext)
       {
          // do authorization logic
          // ...
    
    
          return (/* isAuthorized */);
       }
    
    
       protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
       {
          UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
    
    
          filterContext.Result = new RedirectResult(urlHelper.Action("Index", "Error"));
       }
    }
