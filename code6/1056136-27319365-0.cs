    public class Authorization : AuthorizeAttribute
        {    
            public UserRole RequiredRole { get; set; }
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                var userSession = UserSession.CurrentOrDefault();
                if(userSession != null)
                {
                   int userRole = Convert.ToInt32(userSession.User.Role);
                   int requiredRole = Convert.ToInt32(this.RequiredRole);
                   if(userRole >= requiredRole)
                   {
                
                      return true;
                   }
                   else
                   {
                       return false;
                   }
                }
                return false;
            }
    
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                try
                {
                    if (AuthorizeCore(filterContext.HttpContext))
                    {
                        // ** IMPORTANT **
                        // Since we're performing authorization at the action level, the authorization code runs
                        // after the output caching module. In the worst case this could allow an authorized user
                        // to cause the page to be cached, then an unauthorized user would later be served the
                        // cached page. We work around this by telling proxies not to cache the sensitive page,
                        // then we hook our custom authorization code into the caching mechanism so that we have
                        // the final say on whether a page should be served from the cache.
    
                        HttpCachePolicyBase cachePolicy = filterContext.HttpContext.Response.Cache;
                        cachePolicy.SetProxyMaxAge(new TimeSpan(0));
                        cachePolicy.AddValidationCallback(CacheValidateHandler, null /* data */);
    
                    }
                    else 
                    { 
                       filterContext.Result = new RedirectResult("/Session/Create");
                    }
                }
                catch (Exception)
                {
                    filterContext.Result = new RedirectResult("/Session/Create");
                }
            }
    
            private void CacheValidateHandler(HttpContext context, object data, ref HttpValidationStatus validationStatus)
            {
                validationStatus = OnCacheAuthorization(new HttpContextWrapper(context));
            }
    }
