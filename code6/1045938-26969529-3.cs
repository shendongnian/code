    public class SessionTimeoutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["someValueYouLookFor"] == null)
            {
                filterContext.Result = new RedirectResult("~/Home/Index"); // redirect to login action
            }
            else
            {
                // continue normal execution 
            }
        }
    }
