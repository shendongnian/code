        try
        {
            using (var stream = GenerateClientSecretsStream(this._client_id, this._client_secret))
            {
                GoogleWebAuthorizationBroker.Folder = "Tasks.Auth.Store";
                await StoredCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.Load(stream).Secrets,
                new[] { DriveService.Scope.Drive,
            DriveService.Scope.DriveFile },
                "user",
                CancellationToken.None,
                new SavedDataStore());
            }
        }
        catch (AggregateException ae)
        {
            MessageBox.Show("Error when connecting to Google Drive");
            return;
        }
