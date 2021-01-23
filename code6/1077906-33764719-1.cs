    using Hangfire.Dashboard;
    using System.Collections.Generic;
    using Microsoft.Owin;
    
    public class MyRestrictiveAuthorizationFilter : IAuthorizationFilter
    {
        public bool Authorize(IDictionary<string, object> owinEnvironment)
        {
            var context = new OwinContext(owinEnvironment);
    
            return context.Authentication.User.Identity.IsAuthenticated;
        }
    }
