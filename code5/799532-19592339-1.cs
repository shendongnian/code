    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorize : AuthorizeAttribute
    {
        private int project_id;
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (YourCurrentUserObject.IsPartofProject(project_id)) {
                return true;
            }
            
            return false;
        }
        protected override void OnAuthorization(AuthorizationContext filterContext) 
        {
            //get the "project id" parameter from your action method
            project_id = Convert.ToInt32(filterContext.RouteData.Values.SingleOrDefault(x => x.Key == "project_id").Value);
            base.OnAuthorization(filterContext);
        } 
    }
