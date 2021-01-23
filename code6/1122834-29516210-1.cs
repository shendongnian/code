    public override void OnAuthorization(AuthorizationContext filterContext)
    {
        CheckIfUserIsAuthenticated(filterContext);}
        base.OnAuthorization(filterContext);
    }
