        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            var mgr = context.OwinContext.GetUserManager<ApplicationUserManager>();
            var user = await mgr.FindAsync(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            var usrIdentity = await mgr.CreateIdentityAsync(user, context.Options.AuthenticationType);
            foreach (var c in usrIdentity.Claims)
            {
                identity.AddClaim(c);
            }
            //
            // Add additional claims to your identity
            //
            identity.AddClaim(new Claim("your_custom_claim", "your_custom_claim_value"));
            context.Validated(identity);
        }
