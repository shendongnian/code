    string path = whereYouSaveClientSecret+ "client_secret.json";
    using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
    {
            StoredResponse myStoredResponse = new StoredResponse(RefreshToken);
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
            GoogleClientSecrets.Load(stream).Secrets,
                new[] { DriveService.Scope.Drive},
                "user",
                CancellationToken.None,
                new SavedDataStore(myStoredResponse)).Result;
    }
    DriveService _drive = new DriveService(new BaseClientService.Initializer()
    {
        HttpClientInitializer = credential, 
        ApplicationName = _applicationName
    });
