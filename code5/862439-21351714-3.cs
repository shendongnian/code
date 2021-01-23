    public class LogAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                foreach(KeyValuePair<string, object> argument in actionContext.ActionArguments)
                {
                     ILogable model = argument.Value as ILogable;//assume that only objects implementing this interface are logable
                     if (model != null){
                           //do something with it. Maybe call model.log
                     }  
                }
            }
        
            public override void OnActionExecutedHttpActionExecutedContext actionExecutedContext)
            {
                foreach(KeyValuePair<string, object> argument in actionContext.ActionArguments)
                {
                     ILogable model = argument.Value as ILogable;//assume that only objects implementing this interface are logable
                     if (model != null){
                           //do something with it. Maybe call model.log
                     }  
                }
            }
        }
