    public class RestrictAccess : ActionFilterAttribute
    {
        public UserRole RequiredRole { get; set; }
    
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userSession = UserSession.CurrentOrDefault();
            if(userSession != null)
            {
                int userRole = Convert.ToInt32(userSession.User.Role);
                int requiredRole = Convert.ToInt32(this.RequiredRole);
                if(userRole >= requiredRole)
                {
                    base.OnActionExecuting(filterContext);
                    return;
                }
                else
                {
                    filterContext.Result = new RedirectResult("/");
                    return;
                }
            }
    
            filterContext.Result = new RedirectResult("/Session/Create");
        }
    }
