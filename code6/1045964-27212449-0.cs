           private JObject GenerateLocalAccessTokenResponse(string userName)
        {
 
            var tokenExpiration = TimeSpan.FromDays(1);
 
            ClaimsIdentity identity = new ClaimsIdentity(OAuthDefaults.AuthenticationType);
 
            identity.AddClaim(new Claim(ClaimTypes.Name, userName));
 
            var props = new AuthenticationProperties()
            {
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.Add(tokenExpiration),
            };
 
            var ticket = new AuthenticationTicket(identity, props);
 
            var accessToken = Startup.OAuthBearerOptions.AccessTokenFormat.Protect(ticket);
 
            JObject tokenResponse = new JObject(
                                        new JProperty("userName", userName),
                                        new JProperty("access_token", accessToken),
                                        new JProperty("token_type", "bearer"),
                                        new JProperty("expires_in", tokenExpiration.TotalSeconds.ToString()),
                                        new JProperty(".issued", ticket.Properties.IssuedUtc.ToString()),
                                        new JProperty(".expires", ticket.Properties.ExpiresUtc.ToString())
        );
 
            return tokenResponse;
        }
