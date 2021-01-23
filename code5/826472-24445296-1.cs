    public class AddCustomHeaderFilter : ActionFilterAttribute
    {
       public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
       {
           actionExecutedContext.HttpContext.Response.Headers.Add("ServerTime", DateTime.Now.ToString());
       }
    }
