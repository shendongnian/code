    public Task ChallengeAsync(HttpAuthenticationChallengeContext context,
                                      CancellationToken cancellationToken)
    {
        context.Result = new ResultWithChallenge(context.Result);
        return Task.FromResult(0);
    }
