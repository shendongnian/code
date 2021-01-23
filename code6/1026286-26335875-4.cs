     public class ClaimsAuthorizeAttribute : AuthorizeAttribute
        {
            private readonly string _claimType;
            private readonly string _claimValue;
    
         
            public ClaimsAuthorizeAttribute(string claimType, string claimValue)
            {
                this._claimType = claimType;
                this._claimValue = claimValue;
            }
    
        
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                if (httpContext == null)
                    throw new ArgumentNullException("httpContext");
    
                if (!ApplicationSecurity.IsLoggedIn)
                    return false;
    
                return HasClaim(_claimType, _claimValue);
            }
         }
