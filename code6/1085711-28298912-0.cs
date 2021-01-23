    public class AuthWebsiteAttribute : System.Web.Http.AuthorizeAttribute
    {       
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var auth = actionContext.Request.Headers.Authorization;
            
            if (auth == null)
                return false;
            var param = auth.Parameter;
            
            if (String.IsNullOrEmpty(param))
                return false;
            // now check if the parameter is correct, for example ask your database if the // user email exists or something
            return company != null;
        }
    }
