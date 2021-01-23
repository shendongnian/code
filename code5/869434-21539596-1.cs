    protected void Application_AuthenticateRequest(Object sender, EventArgs e)
    {
        var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
    
        if (authCookie != null)
        {
            var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            var user = this.UserService.GetUserByEmail(authTicket.Name);
    
            var identity = new GenericIdentity(authTicket.Name, "Forms");
    
            // Get the stored user roles
            HttpContext.Current.User = new GenericPrincipal(identity, user.Roles);
        }
    }
