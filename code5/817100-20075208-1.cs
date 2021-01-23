    public override void OnAuthorization(AuthorizationContext filterContext)
    {
        string[] userRoles = System.Web.Security.Roles.GetRolesForUser(filterContext.HttpContext.User.Identity.Name);
        if (!userRoles.Any())
        {
            throw new HttpException(401, "Unauthorized");
        }
        base.HandleUnauthorizedRequest(filterContext);
    }
