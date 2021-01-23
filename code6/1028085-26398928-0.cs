    public class ScreenAccessAuthorize : AuthorizeAttribute
    {
        public ScreenAccessAuthorize( string Roles )
        {
            int v = 0;
            string r = "Admin," + Roles + ".Admin," + Roles + ".Access," + Roles;
            this.Roles = r;
        }
        protected override void HandleUnauthorizedRequest( 
            AuthorizationContext filterContext )
        {
        }
        protected override bool AuthorizeCore( HttpContextBase httpContext )
        {
            return base.AuthorizeCore( httpContext );
        }
    }
