    var fb = new FacebookAuthenticationOptions
    {
        AppId = "...",
        AppSecret = "...",
        SignInAsAuthenticationType = "ExternalCookie",
        Provider = new FacebookAuthenticationProvider
        {
            OnAuthenticated = async ctx =>
                {
                    var access_token = ctx.AccessToken;
                    ctx.Identity.AddClaim(new Claim("access_token", access_token));
                }
        }
    };
    app.UseFacebookAuthentication(fb);
