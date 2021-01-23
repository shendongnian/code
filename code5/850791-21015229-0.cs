    //Now we load our saved refreshToken.
    StoredResponse myStoredResponse = new StoredResponse(tbRefreshToken.Text);
    // Now we pass a SavedDatastore with our StoredResponse.
     using (var stream = new FileStream("client_secrets.json", FileMode.Open,
            FileAccess.Read))
      {
         GoogleWebAuthorizationBroker.Folder = "Tasks.Auth.Store";
         StoredCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
         GoogleClientSecrets.Load(stream).Secrets,
         new[] { DriveService.Scope.Drive,
         DriveService.Scope.DriveFile },
         "user",
          CancellationToken.None,
          new SavedDataStore(myStoredResponse)).Result;
         }
