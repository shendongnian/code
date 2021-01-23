    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    sealed class LocalizedAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.StatusCode = 403;
            string language = filterContext.RouteData.Values["lang"] == null ? "en-us" : filterContext.RouteData.Values["lang"].ToString();
            filterContext.HttpContext.Response.Redirect(string.Format("~/{0}/account/login", language), true);
        }
    }
