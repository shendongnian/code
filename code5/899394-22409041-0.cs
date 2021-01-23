    var sessionSecurityToken = new SessionSecurityToken(principal, TimeSpan.FromHours(Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["SessionSecurityTokenLifeTime"])))
    {
        IsPersistent = true, // Make persistent
        IsReferenceMode = true // Cache on server
    };
    FederatedAuthentication.SessionAuthenticationModule.WriteSessionTokenToCookie(sessionSecurityToken);
