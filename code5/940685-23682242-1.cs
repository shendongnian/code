    /// <summary>
    /// An attribute that can be attached to an individual controller or used globally to prevent the browser from caching the response.
    /// This has nothing to do with server side caching, it simply alters the response headers with instructions for the browser.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class NoCacheAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (!filterContext.IsChildAction && !(filterContext.Result is FileResult))
            {
                filterContext.HttpContext.Response.Cache.SetExpires(DateTime.MinValue);
                filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
                filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
                filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                filterContext.HttpContext.Response.Cache.SetNoStore();
                base.OnResultExecuting(filterContext);
            }
        }
    }
