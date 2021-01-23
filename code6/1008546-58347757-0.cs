      public class CustomAuthAttribute : System.Web.Http.AuthorizeAttribute
        {
            protected override bool IsAuthorized(HttpActionContext context)
            {
                var accessToken = HttpContext.Current.Request.Headers["Authorization"];
                var hash = accessToken.Md5();
                //store the hash for that user 
                //check if the hash is created before the password change or its session was removed by the user
                //store IP address and user agent 
                var isBlackListed = ...
                .....
                return !isBlackListed && base.IsAuthorized(context);
    
            }
        }
