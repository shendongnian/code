    Google.Apis.Auth.OAuth2.Responses.TokenResponse token = new Google.Apis.Auth.OAuth2.Responses.TokenResponse();
                //// Checks if the token is out of date and refresh the access token using the refresh token.
                if (result.Credential.Token.IsExpired(SystemClock.Default))
                {
                    //If the token is expired recreate the token
                    token = await result.Credential.Flow.RefreshTokenAsync(userid.ToString(), result.Credential.Token.RefreshToken, CancellationToken.None);
    
                    //Get the authorization details Results 
                    result = await new AuthorizationCodeMvcApp(this, new AppFlowMetadata()).AuthorizeAsync(cancellationToken);
                }
