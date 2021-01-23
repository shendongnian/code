    app.UseGoogleAuthentication(new Microsoft.Owin.Security.Google.GoogleOAuth2AuthenticationOptions {
        ClientId = ...,
        ClientSecret = ...,
        AccessType = "offline",
        Provider = new Microsoft.Owin.Security.Google.GoogleOAuth2AuthenticationProvider {
            OnAuthenticated = context => {
                if (!String.IsNullOrEmpty(context.RefreshToken)) {
                    context.Identity.AddClaim(new Claim("RefreshToken", context.RefreshToken));
                }
                return Task.FromResult<object>(null);
            }
        });
