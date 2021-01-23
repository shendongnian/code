    /// <summary>
            /// Authenticate to Google Using Oauth2
            /// Documentation https://developers.google.com/accounts/docs/OAuth2
            /// </summary>
            /// <param name="clientId">From Google Developer console https://console.developers.google.com</param>
            /// <param name="clientSecret">From Google Developer console https://console.developers.google.com</param>
            /// <param name="userName">A string used to identify a user.</param>
            /// <returns></returns>
            public static AnalyticsService AuthenticateOauth(string clientId, string clientSecret, string userName)
            {
                
                string[] scopes = new string[] { AnalyticsService.Scope.Analytics,  // view and manage your analytics data
                                                 AnalyticsService.Scope.AnalyticsEdit,  // edit management actives
                                                 AnalyticsService.Scope.AnalyticsManageUsers,   // manage users
                                                 AnalyticsService.Scope.AnalyticsReadonly};     // View analytics data
    
                try
                {
                    // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
                    UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = clientId, ClientSecret = clientSecret }
                                                                                                 , scopes
                                                                                                 , userName
                                                                                                 , CancellationToken.None
                                                                                                 , new FileDataStore("Daimto.GoogleAnalytics.Auth.Store")).Result;
    
                    AnalyticsService service = new AnalyticsService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "Analytics API Sample",
                    });
                    return service;
                }
                catch (Exception ex)
                {
    
                    Console.WriteLine(ex.InnerException);
                    return null;
    
                }
    
            }
