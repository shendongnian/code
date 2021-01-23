    var googleOptions = new GoogleOAuth2AuthenticationOptions()
    {
        ClientId = [INSERT CLIENT ID HERE],
        ClientSecret = [INSERT CLIENT SECRET HERE],
        Provider = new GoogleOAuth2AuthenticationProvider()
        {
            OnAuthenticated = (context) =>
            {
                context.Identity.AddClaim(new Claim("urn:google:name", context.Identity.FindFirstValue(ClaimTypes.Name)));
                context.Identity.AddClaim(new Claim("urn:google:email", context.Identity.FindFirstValue(ClaimTypes.Email)));
                //This following line is need to retrieve the profile image
                context.Identity.AddClaim(new System.Security.Claims.Claim("urn:google:accesstoken", context.AccessToken, ClaimValueTypes.String, "Google"));
                return Task.FromResult(0);
            }
        }
    };
            
    app.UseGoogleAuthentication(googleOptions);
