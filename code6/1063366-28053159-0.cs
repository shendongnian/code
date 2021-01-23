    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            var jsonFormatter = new JsonMediaTypeFormatter();
            var response = new Response();
            response.AddMessage(true, Util.Localization.Authentication.Validation_UserNotAuthenticated); 
           
            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                ReasonPhrase = "Unauthorized",
                Content = new ObjectContent(typeof(Response), response, new JsonMediaTypeFormatter())
            };
            
        }
    }
