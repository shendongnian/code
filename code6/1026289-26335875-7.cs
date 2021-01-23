     public class ClaimsAuthorizeAttribute : AuthorizeAttribute
        {
            private readonly string _claimType;
            private readonly string _claimValue;
    
         
            public ClaimsAuthorizeAttribute(string claimType, string claimValue)
            {
                this._claimType = claimType;
                this._claimValue = claimValue;
            }
 
            private static bool IsLoggedIn
            {
                get {
                    return HttpContext.Current != null && HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated;
                }
            }
        
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                if (httpContext == null)
                    throw new ArgumentNullException("httpContext");
    
                if (!IsLoggedIn)
                    return false;
    
                return HasClaim(_claimType, _claimValue);
            }
         }
