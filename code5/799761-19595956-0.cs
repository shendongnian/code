    public class ExplicitAuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        private readonly MembershipUserRole[] _acceptedRoles;
        public ExplicitAuthorizeAttribute()
        {
        }
        public ExplicitAuthorizeAttribute(params MembershipUserRole[] acceptedRoles)
        {
            _acceptedRoles = acceptedRoles;
        }
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            //Validation ...          
        }
    }
