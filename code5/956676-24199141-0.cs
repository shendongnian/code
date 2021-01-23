    var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                  new ClientSecrets { ClientId = "YourClientId", ClientSecret = "YourClientSecret" },
                  new[] { DriveService.Scope.Drive,
                    DriveService.Scope.DriveFile },
                  "user",
                  CancellationToken.None,
                   new SavedDataStore(myStoredResponse)).Result; }
