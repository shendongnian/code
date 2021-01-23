    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var myModel = actionContext.ActionArguments["myModel"]; 
        }
    
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var myModel = actionContext.ActionArguments["myModel"]; 
        }
    }
     
