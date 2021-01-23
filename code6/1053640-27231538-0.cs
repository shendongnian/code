    private readonly SemaphoreSlim lockObject = new SemaphoreSlim(1);
    public async Task<Token> GenerateToken(Token oldToken)
    {
      Token token;
      await lockObject.WaitAsync();
      try
      {
        var cachedToken = GetTokenFromCache();
        if (cachedToken == oldToken)
        {
          var authClient = new AuthClient(id, key);
          token = await authClient.AuthenticateClientAsync();
          PutTokenInCache(token);
        }
        else
        {
          token = cachedToken;
        }
      }
      finally
      {
        lockObject.Release();
      }
      return token;
    }
