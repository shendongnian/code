    public sealed class UserTokenAuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
             ...
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
             ...
        }
    }
