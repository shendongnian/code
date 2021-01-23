    public class ActionLogFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
             // do your stuff. This is run before control is passed to controller
        }
        public void OnActionExecuted(ActionExecutedContext filterContext) 
        { 
            // do stuff here - control here is passed after controller is done with the action execution
        }
    }
