    public class AppLogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            var ip = ((System.Web.HttpContextWrapper)actionContext.Request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            var userId = Convert.ToInt32(actionContext.RequestContext.Principal.Identity.Name);
            var url = actionContext.Request.RequestUri.ToString();
            var date = DateTime.Now;
            var logEntry = new LogEntry
            {
                Date = date,
                IpAddress = ip,
                Url = url,
                UserID = userId
            };
            // get the AppContext from the current scope 
            var appContext = actionContext.Request.GetDependencyScope().GetService(typeof(AppContext)) as AppContext;
            if (appContext != null)
            {
                appContext.LogEntries.Add(logEntry);
                appContext.SaveChanges();
            }
        }
    }
