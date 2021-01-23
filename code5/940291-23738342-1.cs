     //Now we load our saved refreshToken. Probably from the DB someplace but this works
      StoredResponse myStoredResponse = new StoredResponse(tbRefreshToken.Text);
     // Now we pass a SavedDatastore with our StoredResponse.
    
    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                 new ClientSecrets { ClientId = "YourClientId", ClientSecret = "YourClientSecret" },
                  new[] { DriveService.Scope.Drive,
                    DriveService.Scope.DriveFile },
                  "user",
                  CancellationToken.None,
                   new SavedDataStore(myStoredResponse)).Result; }
