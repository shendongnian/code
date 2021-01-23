            ClientSecrets secrets = new ClientSecrets()
            {
                ClientId = CLIENT_ID,
                ClientSecret = CLIENT_SECRET
            };
            var token = new TokenResponse { RefreshToken = REFRESH_TOKEN }; 
            var credentials = new UserCredential(new GoogleAuthorizationCodeFlow(
                new GoogleAuthorizationCodeFlow.Initializer 
                {
                    ClientSecrets = secrets
                }), 
                "user", 
                token);
            var service = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentials,
                ApplicationName = "TestProject"
            });
