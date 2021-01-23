    public async Task<bool> IsUserAuthenticated()
    {
      var initializer = new GoogleAuthorizationCodeFlow.Initializer 
      { 
        ClientSecrets = new ClientSecrets 
        { 
          ClientId = Constants.ClientId,
          ClientSecret = Constants.ClientSecret
        },
        Scopes = new[] { BloggerService.Scope.Blogger }, 
        DataStore = new StorageDataStore() 
      }; 
      
      var flow = new AuthorizationCodeFlow(initializer); 
      var codeReceiver = new AuthorizationCodeBroker(); 
      var token = await flow.LoadTokenAsync("user", CancellationToken.None).ConfigureAwait(false); 
      if (token == null || (token.RefreshToken == null && token.IsExpired(flow.Clock))) 
      { return false; } 
      else 
      { return true; }
    }
