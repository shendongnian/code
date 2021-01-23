    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var myModel = actionContext.ActionArguments["myModel"]; 
        }
    
        public override void OnActionExecutedHttpActionExecutedContext actionExecutedContext)
        {
            var myModel = actionContext.ActionArguments["myModel"]; 
        }
    }
     
