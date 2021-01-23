    public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
    {
        #if DEBUG
        // CHANGE TO YOUR USER MANAGER
        var user = GETUSER("");
        var principal = new GenericPrincipal(new GenericIdentity(user.Name), new[] { user.RoleName });
        Thread.CurrentPrincipal = principal;
        HttpContext.Current.User = principal;
        
        return;
        #endif
        return base.OnAuthorization(filterContext);
    }
