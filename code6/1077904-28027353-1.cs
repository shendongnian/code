    using Hangfire.Dashboard;
    public class MyRestrictiveAuthorizationFilter : IAuthorizationFilter
    {
        public bool Authorize(IDictionary<string, object> owinEnvironment)
        {
             // In case you need an OWIN context, use the next line.
             var context = new OwinContext(owinEnvironment);
             return false;
        }
    }
