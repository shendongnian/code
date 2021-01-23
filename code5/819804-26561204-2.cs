    public class HideFromAnonymousUsersAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
             actionContext.Response = ActionContext.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Access Restricted");
        }
    }
