    public class AuthenticationFilter : AuthenticationFilterAttribute{
    public override void OnAuthentication(HttpAuthenticationContext context)
    {
        System.Net.Http.Formatting.MediaTypeFormatter jsonFormatter = new System.Net.Http.Formatting.JsonMediaTypeFormatter();
        var ci = context.Principal.Identity as ClaimsIdentity;
        //First of all we are going to check that the request has the required Authorization header. If not set the Error
        var authHeader = context.Request.Headers.Authorization;
        //Change "Bearer" for the needed schema
        if (authHeader == null || authHeader.Scheme != "Bearer")
        {
            context.ErrorResult = context.ErrorResult = new AuthenticationFailureResult("unauthorized", context.Request,
                new { Error = new { Code = 401, Message = "Request require authorization" } });
        }
        //If the token has expired the property "IsAuthenticated" would be False, then set the error
        else if (!ci.IsAuthenticated)
        {
            context.ErrorResult = new AuthenticationFailureResult("unauthorized", context.Request,
                new { Error = new { Code = 401, Message = "The Token has expired" } });
        }
    }}
