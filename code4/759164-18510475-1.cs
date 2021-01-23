    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    internal sealed class LocalizedAuthorizeAttribute : AuthorizeAttribute
    {
            string language = filterContext.RouteData.Values["lang"] == null ? "en-us" : filterContext.RouteData.Values["lang"].ToString();
            filterContext.Result = 
                new RedirectResult
                    (string.Format("~/{0}/account/login?returnUrl={1}",
                                    language,
                                    HttpUtility.UrlEncode(filterContext.HttpContext.Request.Url.AbsolutePath)));
        }
    }
