            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                if (filterContext == null)
                {
                    throw new ArgumentNullException("filterContext");
                }
    
                if (OutputCacheAttribute.IsChildActionCacheActive(filterContext))
                {
                    throw new InvalidOperationException(MvcResources.AuthorizeAttribute_CannotUseWithinChildActionCache);
                }
                
                bool skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true)
                                         || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true);
    
                if (skipAuthorization)
                {
                    return;
                }
    
                if (AuthorizeCore(filterContext.HttpContext))
                {
                    HttpCachePolicyBase cachePolicy = filterContext.HttpContext.Response.Cache;
                    cachePolicy.SetProxyMaxAge(new TimeSpan(0));
    
                    var actionDescriptor = filterContext.ActionDescriptor;
                    var currentAction = actionDescriptor.ActionName;
                    var currentController = actionDescriptor.ControllerDescriptor.ControllerName;
    
                    var hasHttpPostAttribute = actionDescriptor.GetCustomAttributes(typeof(HttpPostAttribute), true).Any();
                    var hasHttpGetAttribute = actionDescriptor.GetCustomAttributes(typeof(HttpGetAttribute), true).Any();
                    // fill the data parameter which is null by default
                    cachePolicy.AddValidationCallback(CacheValidateHandler, new { actionDescriptor : actionDescriptor, currentAction: currentAction, currentController: currentController, hasHttpPostAttribute : hasHttpPostAttribute, hasHttpGetAttribute: hasHttpGetAttribute  });
                }
                else
                {
                    HandleUnauthorizedRequest(filterContext);
                }
            }
        private void CacheValidateHandler(HttpContext context, object data, ref HttpValidationStatus validationStatus)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }
            // the data will contain AuthorizationContext attributes
            bool isAuthorized = myAuthorizationLogic(httpContext, data);
            return (isAuthorized) ? HttpValidationStatus.Valid : httpValidationStatus.IgnoreThisRequest;
        }
