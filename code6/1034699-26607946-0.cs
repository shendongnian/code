    public class MyAttribute: AuthorizeAttribute
    {
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
