    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
    
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
    
            User user = await _service.FindUserAsync(context.UserName, context.Password);
    
            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
            var claims = await _service.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
    
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaims(claims);
    
            context.Validated(identity);
        }
