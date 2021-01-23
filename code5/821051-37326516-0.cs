        try
                    {
                        // we need to call the user authentication credetials verification api )(using linqtotwitter library) to get the user email
                        var authTwitter = new SingleUserAuthorizer
                        {
                            CredentialStore = new SingleUserInMemoryCredentialStore
                            {
                                ConsumerKey = TwConsumerKey,
                                ConsumerSecret = TwConsumerSecret,
                                OAuthToken = accessTokenClaim.Value,
                                OAuthTokenSecret = accessTokenSecretClaim.Value,
                                UserID = ulong.Parse(loginInfo.Login.ProviderKey),
                                ScreenName = loginInfo.DefaultUserName
                            }
                        };
    
                        await authTwitter.AuthorizeAsync();
    
    // call verify credentials api
                        var twitterCtx = new TwitterContext(authTwitter);
                        var verifyResponse =
                              await
                                  (from acct in twitterCtx.Account
                                   where (acct.Type == AccountType.VerifyCredentials) && (acct.IncludeEmail == true)
                                   select acct)
                                  .SingleOrDefaultAsync();
    
                        if (verifyResponse != null && verifyResponse.User != null)
                        {
                            User twitterUser = verifyResponse.User;
      //assign email to existing authentication object
                            loginInfo.Email = twitterUser.Email;
    
                        }
                    }
                    catch (TwitterQueryException tqe)
                    {
                        
                    }
