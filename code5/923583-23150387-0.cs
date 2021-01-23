    void Application_PostAuthenticateRequest(object sender, EventArgs e)
    {
        var ctx = HttpContext.Current;
        if (ctx.Request.IsAuthenticated)
        {
            string[] roles = LookupRolesForUser(ctx.User.Identity.Name);
            var newUser = new GenericPrincipal(ctx.User.Identity, roles);
            ctx.User = Thread.CurrentPrincipal = newUser;
        }
    }
