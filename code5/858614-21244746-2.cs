    public class MyFilterAttribute: ActionFilterAttribute
    {    
        public override void OnActionExecuted(ActionExecutingContext filterContext)
        {
            //You can use this    
            //filterContext.Result
     
             //For example
             var result = filterContext.Result as ViewResultBase;
             if (result == null)
             {
                 // Do something
                 return;
             }
        }
    }
