    public class NotLoggedInFilter : FilterAttribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
             if (!SessionStaticClass.IsUserLoggedIn())
             {
                 filterContext.Result = new RedirectToAction("Login, Login");
             }
        }
    }
