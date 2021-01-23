    public class NewAuth : AuthorizeAttribute
    {
        private Type _type;
        private ActionDescriptor _actionDescriptor;
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            _type = filterContext.Controller.GetType();
            _actionDescriptor = filterContext.ActionDescriptor;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // use _type
            // use _actionDescriptor
            return true;
        }
    }
