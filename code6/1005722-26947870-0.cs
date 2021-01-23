       UserCredential credential;
            try
            {                
                using (var stream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "client_secrets.json"), FileMode.Open, FileAccess.Read))
                {
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        new[] { DriveService.Scope.DriveFile, DriveService.Scope.Drive },
                        acocuntAddress, CancellationToken.None, new FileDataStore("Drive.Auth.Store")).Result;
                }               
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "OutlookPlugin",
                });               
                //give list of files
                    var items = service.Files.List().Execute().Items;
