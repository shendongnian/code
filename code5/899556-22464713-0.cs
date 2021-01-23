    public class VerificationAttribute : ActionFilterAttribute
    {
 
        public VerificationAttribute ()
        {
         }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //We don't care about children/partials
            if (filterContext.IsChildAction)
                return;
             
        }
