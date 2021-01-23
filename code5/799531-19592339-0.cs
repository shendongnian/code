    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //get the "project id" somehow
            if (YourCurrentUserObject.IsPartofProject(ProjectId)) {
                return true;
            }
            
            return false;
        }
    }
