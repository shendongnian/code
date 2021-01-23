    protected void Application_AuthenticateRequest(Object sender, EventArgs e)
    {
        HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
        if (authCookie != null)
        {
          FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
          string[] roles = authTicket.UserData.Split(',');
          GenericPrincipal userPrincipal = new GenericPrincipal(new GenericIdentity(authTicket.Name), roles);
          Context.User = userPrincipal;
        }
    }
