     public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
    
            String deviceId = context.OwinContext.Request.Headers.Get("device_id");
        }
