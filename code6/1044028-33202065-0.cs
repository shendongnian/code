    public static Google.Apis.YouTube.v3.YouTubeService AuthenticateOaut(string clientId, string clientSecret, string userName)
            {
    
                string[] scopes = new string[] { Google.Apis.YouTube.v3.YouTubeService.Scope.Youtube,  // view and manage your YouTube account
                                                 Google.Apis.YouTube.v3.YouTubeService.Scope.YoutubeForceSsl,
                                                 Google.Apis.YouTube.v3.YouTubeService.Scope.Youtubepartner,
                                                 Google.Apis.YouTube.v3.YouTubeService.Scope.YoutubepartnerChannelAudit,
                                                 Google.Apis.YouTube.v3.YouTubeService.Scope.YoutubeReadonly,
                                                 Google.Apis.YouTube.v3.YouTubeService.Scope.YoutubeUpload};
    
                try
                {
                    // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
                    UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = clientId, ClientSecret = clientSecret }
                                                                                                 , scopes
                                                                                                 , userName
                                                                                                 , CancellationToken.None
                                                                                                 , new FileDataStore("Daimto.YouTube.Auth.Store")).Result;
    
                    Google.Apis.YouTube.v3.YouTubeService service = new Google.Apis.YouTube.v3.YouTubeService(new Google.Apis.YouTube.v3.YouTubeService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "Web client 1",
    
                    });
                    return service;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    return null;
    
                }
    
            }
