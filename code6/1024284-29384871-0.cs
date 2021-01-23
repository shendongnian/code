    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method,
        Inherited = true, AllowMultiple = true)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private string _url; // path to action, also you can get it from request
        private Operations _operation; // user requested action (CRUD? or administer, execute, etc.)
        
        // example of usage as attribute [CustomAuthAttrib("some string", Operations.Create)]
        public CustomAuthorizeAttribute(string url, Operations operation)
        {
            _url = url;
            _operation = operation;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // any httpContext.Request... operations
            return base.AuthorizeCore(httpContext);
        }
    }
