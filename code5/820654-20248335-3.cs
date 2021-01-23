    class Class1
    {    
            private static readonly IAuthorizationCodeFlow flow =
                new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
                    {
                        ClientSecrets = new ClientSecrets
                        {
                            ClientId = "...........",
                            ClientSecret = "............"
                        },
                        Scopes = new[] { DriveService.Scope.Drive },
                        DataStore = new FileDataStore("Drive.Api.Auth.Store")
                    });
    }
