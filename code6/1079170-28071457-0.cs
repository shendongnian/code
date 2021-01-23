    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ExtendedAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string _redirectActionName;
        private readonly string _redirectControllerName;
        SimpleAuthorizeAttribute(string redirectActionName, string redirectControllerName)
        {
            _redirectActionName = redirectActionName;
            _redirectControllerName = redirectControllerName;
        }
        public string RedirectActionName 
        { 
            get
            {
                return _redirectActionName;
            } 
        }
        public string RedirectControllerName 
        { 
            get
            {
                return _redirectControllerName;
            } 
        }
    }
