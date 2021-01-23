    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class CheckUserSessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //do not execute the filter logic for Login/Index
            if (filterContext.RouteData.GetRequiredString("controller").Equals("LogIn", StringComparison.CurrentCultureIgnoreCase)
                && filterContext.RouteData.GetRequiredString("action").Equals("Index", StringComparison.CurrentCultureIgnoreCase)){
                return;
            }
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            var user = session["User"];
            if (((user == null) && (!session.IsNewSession)) || (session.IsNewSession))
            {
                session.RemoveAll();
                session.Clear();
                session.Abandon();
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }
            base.OnActionExecuting(filterContext);
        }
    }
