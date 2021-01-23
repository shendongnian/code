    public class RedirectSSLAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(!filterContext.HttpContext.Request.IsSecureConnection)
            {
                filterContext.Result = new RedirectResult("your url");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
