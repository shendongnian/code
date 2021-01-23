    private void Form1_Load(object sender, EventArgs e)
    {
     UserCredential credential;
     using (var stream = new System.IO.FileStream("client_secret.json", System.IO.FileMode.Open, System.IO.FileAccess.Read))
     {
      credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
      GoogleClientSecrets.Load(stream).Secrets,
      new[] { AnalyticsService.Scope.AnalyticsReadonly },
      "user", CancellationToken.None, new FileDataStore("Analytics.Auth.Store")).Result;
      }
