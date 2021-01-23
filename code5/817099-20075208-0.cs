    public class MyCustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.IsInRole("role1"))
            {
                throw new HttpException(401, "Unauthorized");
            }
            base.HandleUnauthorizedRequest(filterContext);
        }
    }
