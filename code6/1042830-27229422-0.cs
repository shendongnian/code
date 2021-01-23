            using Google.Apis.Auth.OAuth2;
            using Google.Apis.Coordinate.v1;
            using Google.Apis.Coordinate.v1.Data;
            using Google.Apis.Services;
            using Google.Apis.Util.Store;
            using (var stream = new FileStream(@"client_secret.json", FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets,
                new[] { CoordinateService.Scope.Coordinate },
                "user", CancellationToken.None,new FileDataStore(folder));
            }
            
            var service = new CoordinateService(new BaseClientService.Initializer()
            {
            HttpClientInitializer = credential,
            ApplicationName = "appname",
            });
            
            var list = await service.Location.List("teamid", "team@mailid.com", 2000).ExecuteAsync();
