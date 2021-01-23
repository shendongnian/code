    var fb = new FacebookAuthenticationOptions
    {
        AppId = "...",
        AppSecret = "...",
        AuthenticationType = "Facebook",
        SignInAsAuthenticationType = "ExternalCookie",
        Provider = new FacebookAuthenticationProvider
        {
            OnAuthenticated = async ctx =>
            {
                if (ctx.User["birthday"] != null)
                {
                    ctx.Identity.AddClaim(new Claim(ClaimTypes.DateOfBirth, ctx.User["birthday"].ToString()));
                }
            }
        }
    };
    fb.Scope.Add("user_birthday");
    app.UseFacebookAuthentication(fb);
