    public class AddCustomHeaderFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
           actionExecutedContext.Response.Content.Headers.Add("customHeader", "custom value date time");
        }
    }
