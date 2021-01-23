    private class SuperSecretBearerAuthClass: OAuthBearerAuthenticationProvider
        {
            public override Task ValidateIdentity(OAuthValidateIdentityContext context)
            {
                var claims = context.Ticket.Identity.Claims; //examine claims here
                base.ValidateIdentity(context);
                return Task.FromResult<object>(null);
            }
        }
