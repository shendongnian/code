    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
    
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
    
            User user = await _service.FindUserAsync(context.UserName, context.Password);
    
            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
    
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "CanViewCompany"));
            identity.AddClaim(new Claim(ClaimTypes.Role, "CanAddCompany"));
            identity.AddClaim(new Claim(ClaimTypes.Role, "CanEditCompany"));
            identity.AddClaim(new Claim(ClaimTypes.Role, "CanDeleteCompany"));
    
            context.Validated(identity);
    
        }
