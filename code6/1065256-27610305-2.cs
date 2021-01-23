    public class KeepSessionAliveAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Session["KeepSessionAlive"] = DateTime.Now;
        }
    }
