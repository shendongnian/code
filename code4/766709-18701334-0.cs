    public class CustomAuthAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool isAuthorized = base.AuthorizeCore(httpContext);
            if (isAuthorized)
            {
                // set culture if user is authorized
            }
            else
            {
                // set culture if user is not authorized
            }
            return isAuthorized;
        }
    }
