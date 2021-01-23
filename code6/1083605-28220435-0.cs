    public class SetDepartmentFilter : IAuthorizationFilter 
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var userInfo = GetUserInfo(filterContext);
            if (userInfo.IsAuthorized)
            {
                filterContext.HttpContext.Session["userDeparment"] = userInfo.Department;
            }
        }
        private UserInfo GetUserInfo(AuthorizationContext filterContext)
        {
            // TODO: see if authorized, get department, etc.
        }
    }
