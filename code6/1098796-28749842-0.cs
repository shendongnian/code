     public class GoogleAuthAttribute : FilterAttribute, IAuthenticationFilter
        {
            public void OnAuthentication(AuthenticationContext filterContext)
            {
                
                IIdentity ident = filterContext.Principal.Identity;
    
                if (!ident.IsAuthenticated || !ident.Name.EndsWith("@google.com"))
                {
                    filterContext.Result = new HttpUnauthorizedResult();
                }
            }
    
            public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
            {
                if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
                {
                    filterContext.Result =
                        new RedirectToRouteResult(new RouteValueDictionary
                        {
                            {"controller", "GoogleAccount"},
                            {"action", "Login"},
                            {"returnUrl", filterContext.HttpContext.Request.RawUrl}
                        });
                }
           
            }
        }
 
   
  
