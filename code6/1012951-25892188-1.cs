    protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
    {
        if (User.Identity != null && User.Identity.IsAuthenticated)
        {
            CustomPrincipal opPrincipal = new CustomPrincipal(User.Identity.Name);
            HttpContext.Current.User = opPrincipal;
        }
    }
