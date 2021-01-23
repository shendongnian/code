            ClientSecrets secrets = new ClientSecrets()
            {
                ClientId = CLIENT_ID,
                ClientSecret = CLIENT_SECRET
            };
            var token = new TokenResponse { RefreshToken = REFRESH_TOKEN };
            var credentials = new UserCredential(new GoogleAuthorizationCodeFlow(
            new GoogleAuthorizationCodeFlow.Initializer { ClientSecrets = secrets }),
            "user", token);
            var service = new YouTubeService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credentials,
                ApplicationName = "your-app-name"
            });
            var broadcast = new LiveBroadcast
            {
                Kind = "youtube#liveBroadcast",
                Snippet = new LiveBroadcastSnippet
                {
                    Title = eventTitle,
                    ScheduledStartTime = eventStartDate
                },
                Status = new LiveBroadcastStatus { PrivacyStatus = "public" }
            };
            var request = service.LiveBroadcasts.Insert(broadcast, "id,snippet,status");
            var response = request.Execute();
            return response.Id;
        }
    </pre>
