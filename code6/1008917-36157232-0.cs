    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
        public class MyAuthorizedAttribute : AuthorizeAttribute
        {
            public bool CheckPermissions(HttpContextBase httpContext, string controller, string action)
            {
                bool authorized;
    
                //Validate User permissions of the way you think is best
                return authorized;
            }
    
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                var action = filterContext.ActionDescriptor.ActionName;
                var controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                if (filterContext == null)
                {
                    throw new ArgumentNullException(nameof(filterContext));
                }
    
                if (OutputCacheAttribute.IsChildActionCacheActive(filterContext))
                {
                    // If a child action cache block is active, we need to fail immediately, even if authorization
                    // would have succeeded. The reason is that there's no way to hook a callback to rerun
                    // authorization before the fragment is served from the cache, so we can't guarantee that this
                    // filter will be re-run on subsequent requests.
                    throw new InvalidOperationException("AuthorizeAttribute Cannot Use Within Child Action Cache");
                }
    
                var skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof (AllowAnonymousAttribute), true)
                                        ||
                                        filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(
                                            typeof (AllowAnonymousAttribute), true);
    
                if (skipAuthorization)
                {
                    return;
                }
    
                if (AuthorizeCore(filterContext.HttpContext) && CheckPermissions(filterContext.HttpContext, controller, action))
                {
                    // ** IMPORTANT **
                    // Since we're performing authorization at the action level, the authorization code runs
                    // after the output caching module. In the worst case this could allow an authorized user
                    // to cause the page to be cached, then an unauthorized user would later be served the
                    // cached page. We work around this by telling proxies not to cache the sensitive page,
                    // then we hook our custom authorization code into the caching mechanism so that we have
                    // the final say on whether a page should be served from the cache.
    
                    var cachePolicy = filterContext.HttpContext.Response.Cache;
                    cachePolicy.SetProxyMaxAge(new TimeSpan(0));
                    cachePolicy.AddValidationCallback(CacheValidateHandler, null /* data */);
                }
                else
                {
                    HandleUnauthorizedRequest(filterContext);
                }
            }
    
            private void CacheValidateHandler(HttpContext context, object data, ref HttpValidationStatus validationStatus)
            {
                validationStatus = OnCacheAuthorization(new HttpContextWrapper(context));
            }
    
            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
                if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    base.HandleUnauthorizedRequest(filterContext);
                }
                else
                {
                    filterContext.Result =
                        new RedirectToRouteResult(
                            new RouteValueDictionary(new {controller = "Error", action = "Unauthorized"}));
                }
            }
        }
