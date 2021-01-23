      var facebookAuthOptions = new FacebookAuthenticationOptions();
            facebookAuthOptions.AppId = "..."; //Enter your AppId
            facebookAuthOptions.AppSecret = "..."; //Enter your AppSecret
     facebookAuthOptions.Provider = new FacebookAuthenticationProvider()
        {
            OnAuthenticated = async context =>
                {
                    context.Identity.AddClaim(new System.Security.Claims.Claim("FacebookAccessToken", context.AccessToken));
                    foreach (var claim in context.User)
                    {
                        var claimType = string.Format("urn:facebook:{0}", claim.Key);
                        string claimValue = claim.Value.ToString();
                        if (!context.Identity.HasClaim(claimType, claimValue))
                            context.Identity.AddClaim(new System.Security.Claims.Claim(claimType, claimValue, "XmlSchemaString", "Facebook"));
                    }
                }
        };
