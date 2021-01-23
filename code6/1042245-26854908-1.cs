    public class ExitHttpsAttribute : FilterAttribute, IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationContext filterContext)
            {
                if (filterContext == null)
                {
                    throw new ArgumentException("Filter Context");
                }
    
                if (filterContext.HttpContext == null)
                {
                    return;
                }
    
                var isSecure = filterContext.HttpContext.Request.IsSecureConnection;
    
                var currentUrl = filterContext.HttpContext.Request.Url;
                if (!isSecure && currentUrl.Scheme.Equals(Uri.UriSchemeHttps, StringComparison.CurrentCultureIgnoreCase))
                {
                    isSecure = true;
                }
    
                if (!isSecure && string.Equals(filterContext.HttpContext.Request.Headers["X-Forwarded-Proto"], "https", StringComparison.InvariantCultureIgnoreCase))
                {
                    isSecure = true;
                }
    
                if (isSecure)
                {
                    //in these cases keep https
                    // abort if a [RequireHttps] attribute is applied to controller or action
                    if (filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof (RequireHttpsAttribute), true).Length > 0)
                    {
                        isSecure = false;
                    }
    
                    if (isSecure && filterContext.ActionDescriptor.GetCustomAttributes(typeof (RequireHttpsAttribute), true).Length > 0)
                    {
                        isSecure = false;
                    }
    
                    // abort if a [RetainHttps] attribute is applied to controller or action
                    if (isSecure && filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof (RetainHttpsAttribute), true).Length > 0)
                    {
                        isSecure = false;
                    }
    
                    if (isSecure && filterContext.ActionDescriptor.GetCustomAttributes(typeof (RetainHttpsAttribute), true).Length > 0)
                    {
                        isSecure = false;
                    }
    
                    // abort if it's not a GET request - we don't want to be redirecting on a form post
                    if (isSecure && !String.Equals(filterContext.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                    {
                        isSecure = false;
                    }
                }
    
                if (!isSecure)
                {
                    return;
                }
    
                // redirect to HTTP
                var url = "http://" + filterContext.HttpContext.Request.Url.Host + filterContext.HttpContext.Request.RawUrl;
                filterContext.Result = new RedirectResult(url);
            }
        }
