    public class MyNewSecurityAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // I may not need this; as I could still use the original [Authorize] on MyPage()
            if (!httpContext.Request.IsAuthenticated)
                return false;
            // Area/Controller/Action
            // Controller/Action
            // Controller [default for index]
            var path = httpContext.Request.CurrentExecutionFilePath
            var structure = path.Split(new[] {"/"}, StringSplitOptions.RemoveEmptyEntries);
            var sAreaName = "";
            var sControllerName = "";
            var sActionsName = "";
            switch (structure.Length)
            {
                case 1:
                    sController = structure[0];
                    sActions = "Index";
                    break;
                case 2:
                    sController = structure[0];
                    sActions = structure[1];
                    break;
                case 3:
                    sArea = structure[0];
                    sController = structure[1];
                    sActions = structure[2];
                    break;
                default:
                    return false;
            }
            var menuKey = string.Format("menu_{0}_{1}_{2}", sArea, sController, sActions);
            // Roles for the menu are named to the above format
            return httpContext.User.IsInRole(menuStructure);
        }
    }
