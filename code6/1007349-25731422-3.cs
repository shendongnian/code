    using System.Security.Claims;
    using System.Web.Mvc;
    using System.Web.Mvc.Filters;
    public class AppAuthenticationFilterAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            //This method is responsible for setting and modifying the principle for the current request though the filterContext .
            //Here you can modify the principle or applying some authentication logic.  
            var principal = filterContext.Principal as ClaimsPrincipal;
            if (principal != null && !(principal is UserPrincipal))
            {
                filterContext.Principal = new UserPrincipal(principal);
            }
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            //This method is responsible for validating the current principal and permitting the execution of the current action/request.
            //Here you should validate if the current principle is valid / permitted to invoke the current action. (However I would place this logic to an authorization filter)
            //filterContext.Result = new RedirectToRouteResult("CustomErrorPage",null);
        }
    }
