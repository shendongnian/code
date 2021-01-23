    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    public class CustomAuthorizeAttribute : System.Web.Http.Filters.AuthorizationFilterAttribute
    {   
        public override bool AllowMultiple
        {
            get { return false; }
        }
    
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //Perform your logic here
            base.OnAuthorization(actionContext);
        }
    }
