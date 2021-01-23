    UserCredential credential; 
    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
              new ClientSecrets { ClientId = "YourClientId", ClientSecret = "YourClientSecret" },
              new[] { AnalyticsService.Scope.AnalyticsReadonly },
              "user",
              CancellationToken.None,
              new FileDataStore("Drive.Auth.Store")).Result; }
