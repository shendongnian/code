       public class FacebookAuthProvider : FacebookAuthenticationProvider
        {
            public override Task Authenticated(FacebookAuthenticatedContext context)
            {
                context.Identity.AddClaim(new Claim("ExternalAccessToken", context.AccessToken));
                return Task.FromResult<object>(null);
            }
        }
