    public class CustomLoggerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            // Here goes your logic
        }
        // ...
    }
