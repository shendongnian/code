    app.UseOpenIdConnectAuthentication(
        new OpenIdConnectAuthenticationOptions
        {
            ...
            Notifications = new OpenIdConnectAuthenticationNotifications
            {   
                ...         
                RedirectToIdentityProvider = async context =>
                {
                    if (!context.Request.Accept.Contains("html"))
                    {
                        context.HandleResponse();
                    }
                },
                ...
            }
        });
