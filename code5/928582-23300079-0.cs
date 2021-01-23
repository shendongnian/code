    public class IdentityImpersonateActionFilter : ActionFilterAttribute
    {
        IDisposable usingVaribale;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            usingVaribale = WindowsIdentity.GetCurrent().Impersonate();
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            usingVaribale.Dispose();
        }
    }
