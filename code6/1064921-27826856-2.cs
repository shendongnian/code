    void SessionAuthenticationModule_SessionSecurityTokenReceived(object sender, SessionSecurityTokenReceivedEventArgs e)
    {
        SessionAuthenticationModule sam = FederatedAuthentication.SessionAuthenticationModule;
    
        var token = e.SessionToken;
        var duration = token.ValidTo.Subtract(token.ValidFrom);
        if (duration <= TimeSpan.Zero) return;
    
        var diff = token.ValidTo.Add(sam.FederationConfiguration.IdentityConfiguration.MaxClockSkew).Subtract(DateTime.UtcNow);
        if (diff <= TimeSpan.Zero) return;
    
        var halfWay = duration.TotalMinutes / 2;
        var timeLeft = diff.TotalMinutes;
        if (timeLeft <= halfWay)
        {
            e.ReissueCookie = true;
            e.SessionToken =
                new SessionSecurityToken(
                    token.ClaimsPrincipal,
                    token.Context,
                    DateTime.UtcNow,
                    DateTime.UtcNow.Add(duration))
                {
                    IsPersistent = token.IsPersistent,
                    IsReferenceMode = token.IsReferenceMode
                };
        }
    }
