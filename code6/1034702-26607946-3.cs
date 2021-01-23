    public class MyAttribute: AuthorizeAttribute
    {
        # Warning - this code doesn't work - see comments
        private AuthorizationContext _currentContext;
        
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
             _currentContext = filterContext;
             base.OnAuthorization(filterContext);
        }
    
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
             // use _currentContext
        }    
    }
