    protected virtual IEnumerable<ViewModels.OAuthClient> GetViewModelOAuthClients(
                     IEnumerable<IOAuthClient> oAuthClients)
    {
      oAuthClients.ForEach(client => { client.GetLoginUrl(); });
    
      return oAuthClients.Select(c => (ViewModels.OAuthClient)(OAuthClient)c);
    }
