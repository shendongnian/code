     public async Task<UserCredential> getUserCredential()
        {
            UserCredential credential;
            string[] scopes = new string[] {  }; // user basic profile
            //Read client id and client secret from Web config file
            credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                       new ClientSecrets
                       {
                           ClientId = ConfigurationManager.AppSettings["ClientId"],
                           ClientSecret = ConfigurationManager.AppSettings["ClientSecret"]
                       }, scopes,
                "user", CancellationToken.None, new FileDataStore("Auth.Api.Store"));
            return credential;
        }
