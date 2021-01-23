    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
        public class AuthorizeAttribute : AuthorizationFilterAttribute
        {       
            public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
            {
                base.OnAuthorization(actionContext);            
    
                ////check authentication and return if not authorized
                if (actionContext != null)
                {
                    if (!WebSecurity.IsAuthenticated)
                    {
                        actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized) { RequestMessage = actionContext.ControllerContext.Request };
                         return;
                    }             
    
                }
            }
        }
