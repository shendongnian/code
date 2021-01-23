    public class LogAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                foreach(var argument in actionContext.ActionArguments.Values.Where(v => v is ILogable)))
                {
                     ILogable model = argument as ILogable;//assume that only objects implementing this interface are logable
                     //do something with it. Maybe call model.log
                }
            }
        
            public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
            {
                foreach(var argument in actionContext.ActionArguments.Values.Where(v => v is ILogable)))
                {
                     ILogable model = argument as ILogable;//assume that only objects implementing this interface are logable
                     //do something with it. Maybe call model.log
                }
            }
        }
