        [Test]
        public async void GetNewTokenByRefresh()
        {
            var authClient = new LiveAuthClient(OneNoteApiConfig.ClientID, new TestRefreshTokenHandler());
            var res = (await authClient.InitializeAsync(OneNoteApiConfig.Scopes)).Session;
            
            Console.WriteLine("\r\nLiveConnectSession.AccessToken = " + res.AccessToken);
            Console.WriteLine("\r\nLiveConnectSession.AuthenticationToken = " + res.AuthenticationToken);
            Console.WriteLine("\r\nLiveConnectSession.Expires = " + res.Expires);
            Console.WriteLine("\r\nLiveConnectSession.RefreshToken = " + res.RefreshToken);
            res.AuthenticationToken.Should().NotBeNullOrWhiteSpace();
        }
