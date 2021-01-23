    public class CustomErrorAttribute : HandleErrorAttribute
    {
        public CustomErrorAttribute(string[] requestPropertiesToLog)
        {
            this.requestPropertiesToLog = requestPropertiesToLog;
        }
        public string[] requestPropertiesToLog { get; set; }
        public override void OnException(ExceptionContext filterContext)
        {
            var requestDetails = this.GetPropertiesFromRequest(filterContext);
            // do custom logging / handling
            LogExceptionToEmail(requestDetails, filterContext);
            LogExceptionToFile(requestDetails, filterContext);
            LogExceptionToElseWhere(requestDetails, filterContext);// you get the idea
            // even better - you could use DI (as you're in MVC at this point) to resolve the custom logging and log from there.
            //var logger = DependencyResolver.Current.GetService<IMyCustomErrorLoggingHandler>();
            // logger.HandleException(requestDetails, filterContext);
            // then let the base error handling do it's thang.
            base.OnException(filterContext);
        }
        private IEnumerable<KeyValuePair<string, string>> GetPropertiesFromRequest(ExceptionContext filterContext)
        {
            // in requestContext is the queryString, form, user, route data - cherry pick bits out using the this.requestPropertiesToLog and some simple mechanism you like
            var requestContext = filterContext.RequestContext;
            var qs = requestContext.HttpContext.Request.QueryString;
            var form = requestContext.HttpContext.Request.Form;
            var user = requestContext.HttpContext.User;
            var routeDataOfActionThatThrew = requestContext.RouteData;
            yield break;// just break as I'm not implementing it.
        }
        private void LogExceptionToEmail(IEnumerable<KeyValuePair<string, string>> requestDetails, ExceptionContext filterContext)
        {
            // send emails here
        }
        private void LogExceptionToFile(IEnumerable<KeyValuePair<string, string>> requestDetails, ExceptionContext filterContext)
        {
            // log to files
        }
        private void LogExceptionToElseWhere(IEnumerable<KeyValuePair<string, string>> requestDetails, ExceptionContext filterContext)
        {
            // send cash to me via paypal everytime you get an exception ;)
        }
    }
