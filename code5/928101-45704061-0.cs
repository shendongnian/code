    public bool AllowMultiple
    {
        get { return true; }
    }
    public Task AuthenticateAsync(HttpAuthenticationContext context, 
                                        CancellationToken cancellationToken)
    {
        if (context.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
        {
            context.ActionContext.Response = new HttpResponseMessage(
                                    System.Net.HttpStatusCode.Forbidden);
        }
        return Task.FromResult<object>(null);
    }
    public Task ChallengeAsync(HttpAuthenticationChallengeContext context,
                                        CancellationToken cancellationToken)
    {
        return Task.FromResult<object>(null);
    }
}
