    app.UseGoogleAuthentication(new Microsoft.Owin.Security.Google.GoogleOAuth2AuthenticationOptions {
        ClientId = ...,
        ClientSecret = ...,
        AccessType = "offline",
        Provider = new Microsoft.Owin.Security.Google.GoogleOAuth2AuthenticationProvider {
            OnAuthenticated = context => {
                var refreshToken = context.RefreshToken;
                context.Identity.AddClaim(new Claim("RefreshToken", refreshToken));
                return Task.FromResult<object>(null);
            }
        });
