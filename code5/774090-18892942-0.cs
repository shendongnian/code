    public sealed class AuthorizationAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //do custom authorization here
            base.OnAuthorization(filterContext);
        }
    }
