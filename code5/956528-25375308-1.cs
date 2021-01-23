    public UserCredential GetRefreshToken(string refreshToken, string clientID, string clientSecret, string[] scopes)
    {
    	TokenResponse token = new TokenResponse
        {
    		RefreshToken = refreshToken
        };
        
        IAuthorizationCodeFlow flow = new AuthorizationCodeFlow(new AuthorizationCodeFlow.Initializer(Google.Apis.Auth.OAuth2.GoogleAuthConsts.AuthorizationUrl, Google.Apis.Auth.OAuth2.GoogleAuthConsts.TokenUrl)
    	{
    		ClientSecrets = new ClientSecrets
    		{
    			ClientId = clientID,
    			ClientSecret = clientSecret
    		},
    		Scopes = scopes
    	});
    
    	UserCredential credential = new UserCredential(flow, "me", token);
    	try
    	{
    		bool success = credential.RefreshTokenAsync(CancellationToken.None).Result;
    	}
    	catch
    	{
    		throw;
    	}
    	return credential;
    }
