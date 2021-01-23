    public class AuthorizeUser : AuthorizeAttribute
    {
        public String UserRole { get; set; }
        public string OrganizationType { get; set; }
    
        private bool _hasPermission;
    
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }
    
            _hasPermission = CheckOrganizationType.checkRole(this.UserRole, this.OrganizationType, Auth.CurrentUser);
            return true;
        }
    
        public override void OnAuthorization(AuthorizationContext filterContext)
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
             
                if (!_hasPermission)
                {
                   filterContext.Result = new RedirectResult("/YourHasNoPermissionUrl")
                }
             } 
             else 
             {
                 filterContext.Result = new RedirectResult("/YourUnauthorizedUrl")
             }
    
         }
         private void CacheValidateHandler(HttpContext context, object data, ref HttpValidationStatus validationStatus)
         {
             validationStatus = OnCacheAuthorization(new HttpContextWrapper(context));
         }
    }
