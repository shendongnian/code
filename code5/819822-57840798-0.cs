    protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
            {
                var httpContext = HttpContext.Current;
                if (httpContext == null)
                {
                    base.HandleUnauthorizedRequest(actionContext);
                    return;
                }
    
                actionContext.Response = httpContext.User.Identity.IsAuthenticated == false ?
                    actionContext.Request.CreateErrorResponse(
                  System.Net.HttpStatusCode.Unauthorized, "Unauthorized") :
                   actionContext.Request.CreateErrorResponse(
                  System.Net.HttpStatusCode.Forbidden, "Forbidden");
            
                httpContext.Response.SuppressFormsAuthenticationRedirect = true;
                httpContext.Response.End();
            }
