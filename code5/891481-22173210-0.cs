    public class TokenAuthenticationAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            // In auth web method you should implement functionality of authentication
            // so that client app could be able to get token
            if (actionContext.Request.RequestUri.AbsolutePath.Contains("api/auth"))
            {
                return;
            }
    
            // Receive token from the client. Here is the example when token is in header:
            var token = actionContext.Request.Headers["Token"];
            // Put your secret key into the configuration
            var secretKey = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";
            try
            {
                string jsonPayload = JWT.JsonWebToken.Decode(token, secretKey);
            }
            catch (JWT.SignatureVerificationException)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }    
        }
    }
