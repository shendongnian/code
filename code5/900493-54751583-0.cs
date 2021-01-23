    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class CustomHeaders : System.Web.Mvc.ActionFilterAttribute
    {
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            context.RequestContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.RequestContext.HttpContext.Response.Cache.AppendCacheExtension("no-store, must-revalidate");
            context.RequestContext.HttpContext.Response.AppendHeader("Pragma", "no-cache");
            context.RequestContext.HttpContext.Response.AppendHeader("Expires", "0");
            base.OnActionExecuted(context);
        }
    }
