    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    public class AuthAttribute : System.Web.Http.AuthorizeAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //authorization stuff here
        }
    }
