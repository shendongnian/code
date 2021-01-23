    public class HashCodeCheckFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var passcode = filterContext.HttpContext.Request.QueryString["passcode"];
            // Validate passcode
            var valid = false;
            // If invalid then do some error processing
            if (!valid)
            {
                // Redirect to errro page....
                filterContext.Result = new RedirectToRouteResult("NameOfErrorRoute");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
