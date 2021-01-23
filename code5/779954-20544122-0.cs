    void WSFederationAuthenticationModule_SessionSecurityTokenCreated(object sender, SessionSecurityTokenCreatedEventArgs e)
    {
        var currentToken = e.SessionToken;
        var validForDays = 1;
        e.SessionToken = new SessionSecurityToken(
            currentToken.ClaimsPrincipal,
            currentToken.Context,
            currentToken.EndpointId,
            DateTime.UtcNow,
            DateTime.UtcNow.AddDays(validForDays));
        e.SessionToken.IsPersistent = true;
    }
