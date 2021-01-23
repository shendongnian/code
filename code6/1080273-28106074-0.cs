    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(!filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                // CHECK HASH HERE
            }
            base.OnActionExecuting(filterContext);
        }
    }
