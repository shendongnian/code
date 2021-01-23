     UserCredential credential;
     using (var stream = new FileStream("client_secrets.json",
                                        FileMode.Open, FileAccess.Read))
     {
         credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
             GoogleClientSecrets.Load(stream).Secrets,
             new[] { [CoordinateService.Scope.Coordinate },
             "user", CancellationToken.None,
             new FileDataStore("CredentialsStore"));
     }
    
     // Create the service.
     var service = new CoordinateService(new BaseClientService.Initializer()
     {
         HttpClientInitializer = credential,
         ApplicationName = "Coordinate .NET library",
     });
     ... and here call one of the service's methods.
