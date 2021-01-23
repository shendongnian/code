    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class SuppressHeadersAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //suppress headers here
            //filterContext has access to the HttpContext
        }
    }
