    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class BlockProxyAccessAttribute : ActionFilterAttribute
    {
        private static readonly string[] HEADER_KEYS = { "VIA", "FORWARDED", "X-FORWARDED-FOR", "CLIENT-IP" };
        private const string PROXY_REDIR_URL = "/error/proxy";
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var isProxy = filterContext.HttpContext.Request.Headers.AllKeys.Any(x => HEADER_KEYS.Contains(x));
            if (isProxy)
                filterContext.Result = new RedirectResult(PROXY_REDIR_URL);
        }
    }
