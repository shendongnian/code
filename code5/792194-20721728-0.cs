    public class ClaimsAuthorizeAttribute : AuthorizeAttribute
    {
        protected bool _canOverride = true;
        //...custom authorization code goes here.....
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //Don't authorize if the override attribute exists
            if (_canOverride && actionContext.ActionDescriptor.GetCustomAttributes<OverrideClaimsAuthorizeAttribute>().Any())
            {
                return;
            }
            base.OnAuthorization(actionContext);
        }
    }
    public class OverrideClaimsAuthorizeAttribute : ClaimsAuthorizeAttribute
        {
            public OverrideClaimsAuthorizeAttribute ()
                : base()
            {
                _canOverride = false;
            }
    
        }
