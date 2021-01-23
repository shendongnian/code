    public override async Task TokenEndpoint(OAuthTokenEndpointContext context)
    {
        context.AdditionalResponseParameters.Add("username", "user@mail.com");
        return Task.FromResult<object>(null);
    }
