    public class CustomAuthenticationAttribute : ActionFilterAttribute, IAuthenticationFilter 
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
                var user = filterContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            // modify filterContext.Result to go somewhere special...if you do
            // nothing here they will just go to the site's default login
        }
    }
