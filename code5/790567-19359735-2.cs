    public class VerifySomethingAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (based_on_some_check)
            {
                filterContext.Result = new RedirectResult(url);
            }
            base.OnActionExecuting(filterContext);
        }
    }
