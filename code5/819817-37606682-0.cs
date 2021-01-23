    public class MyAuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);
            HttpContext.Current.Response.SuppressFormsAuthenticationRedirect = true;
        }
    }
