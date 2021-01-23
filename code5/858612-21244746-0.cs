    public class MyFilterAttribute: ActionFilterAttribute
    {    
        public override void OnActionExecuted(ActionExecutingContext filterContext)
        {
            //You can use this    
            //filterContext.Result
        }
    }
