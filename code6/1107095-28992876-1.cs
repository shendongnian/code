    app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
    app.UseCookieAuthentication(new CookieAuthenticationOptions());
    app.UseOpenIdConnectAuthentication(
        new OpenIdConnectAuthenticationOptions
        {
            ClientId = "AppGUID",
            Authority = "https://login.windows.net/MyDomain.com",
            // After authentication return user to the page they were trying
            // to access before being redirected to the Azure AD signin page.
            Notifications = new OpenIdConnectAuthenticationNotifications()
            {
                RedirectToIdentityProvider = (context) =>
                    {
                        string currentUrl = context.Request.Scheme + "://" + context.Request.Host + context.Request.Path;
                        context.ProtocolMessage.RedirectUri = currentUrl;
                        return Task.FromResult(0);
                    }
            }
        });
