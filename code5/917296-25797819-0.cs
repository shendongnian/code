    private async Task<GoogleAuthorizationCodeFlow.Initializer> InitInitializer()
    {
        _iDataStore = await _userCredential.GetDataStore(); //new StorageDataStore()
        var initializer = new GoogleAuthorizationCodeFlow.Initializer
        {
            ClientSecrets = new ClientSecrets
            {
                ClientId = ClientId, //"PUT_CLIENT_ID_HERE",
                ClientSecret = ClientSecret, //"PUT_CLIENT_SECRET_HERE"
            },
            Scopes = new[] { TasksService.Scope.Tasks },
            DataStore = (Google.Apis.Util.Store.IDataStore)_iDataStore //new StorageDataStore()
        };
        return initializer;
    }
