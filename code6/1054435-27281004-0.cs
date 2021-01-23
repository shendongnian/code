    private static async Task<UserCredential> AuthorizeAsync()
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
      { 
        var redirectUri = codeReceiver.RedirectUri; 
        AuthorizationCodeRequestUrl codeRequest = flow.CreateAuthorizationCodeRequest(redirectUri); 
        var response = await codeReceiver.ReceiveCodeAsync(codeRequest, CancellationToken.None).ConfigureAwait(false); 
        if (string.IsNullOrEmpty(response.Code)) 
        { 
          var errorResponse = new TokenErrorResponse(response); 
          throw new TokenResponseException(errorResponse); 
        } 
 
        token = await flow.ExchangeCodeForTokenAsync("user", response.Code, codeReceiver.RedirectUri, 
                    CancellationToken.None).ConfigureAwait(false); 
      } 
      m_credential = new UserCredential(flow, "user", token); 
      return m_credential;
    }
