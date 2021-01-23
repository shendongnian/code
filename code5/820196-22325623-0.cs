    var ms = new Microsoft.Owin.Security.MicrosoftAccount.MicrosoftAccountAuthenticationOptions();
    ms.Scope.Add("wl.emails");
    ms.Scope.Add("wl.basic");
    ms.ClientId = "xxxxxxxxxxxxxxxxxxxxxx";
    ms.ClientSecret = "yyyyyyyyyyyyyyyyyyyyy";
    ms.Provider = new Microsoft.Owin.Security.MicrosoftAccount.MicrosoftAccountAuthenticationProvider()
    {
        OnAuthenticated = async context =>
        {
            context.Identity.AddClaim(new System.Security.Claims.Claim("urn:microsoftaccount:access_token", context.AccessToken));
            foreach (var claim in context.User)
            {
                var claimType = string.Format("urn:microsoftaccount:{0}", claim.Key);
                string claimValue = claim.Value.ToString();
                if (!context.Identity.HasClaim(claimType, claimValue))
                    context.Identity.AddClaim(new System.Security.Claims.Claim(claimType, claimValue, "XmlSchemaString", "Microsoft"));
            }
        }
    };
    app.UseMicrosoftAccountAuthentication(ms);
