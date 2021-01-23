    public class ExternalApiTraceAttribute : ActionFilterAttribute
    {
        
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
           ...
            var externalApiAudit = new ExternalApiAudit()
            {
                Method = actionContext.Request.Method.ToString(),
                RequestPath = actionContext.Request.RequestUri.AbsolutePath,
                IpAddresss = ((HttpContextWrapper)actionContext.Request.Properties["MS_HttpContext"]).Request.UserHostAddress,
                DateOccurred = DateTime.UtcNow,
                Arguments = Serialize(actionContext.ActionArguments)
            };
