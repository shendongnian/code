    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return GetUsersecurityLevel();
        }
    
        public override void OnAuthorization(AuthorizationContext filterContext)
        {            
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
    
            if (!AuthorizeCore(filterContext.HttpContext))
            {
                 // If not authorized, redirect to the NotAuthorizedForApplication action 
                 filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary {
                       {"action", "NotAuthorizedForApplication"}
                    }
                 );               
            }
        }
        private bool GetUserSecurityLevel()
        {
            // Your code to authorize users...
        }
    }
