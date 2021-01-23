    protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                IUnityContainer container = GetUnityContainer();
                ISecurityService securityService = container.Resolve<SecurityService>();
                var list = securityService.GetUserRolesandPermissions("1");
            }
        }
