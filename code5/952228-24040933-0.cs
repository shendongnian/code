    public class MyAuthorizationAttribute : AuthorizeAttribute
        {
            public override void OnAuthorization(HttpActionContext actionContext)
            {
                var principal = actionContext.Request.GetRequestContext().Principal;
                if (!principal.IsInRole(this.Roles))
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
            }
        }
