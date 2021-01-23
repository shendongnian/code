    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using System.IO;
    using Google.Apis.Drive.v2;
    using Google.Apis.Util.Store;
    using System.Threading;
    private void Form1_Load(object sender, EventArgs e)
     {
     UserCredential credential;
     using (var stream = new FileStream("client_secrets.json", FileMode.Open,
                                     FileAccess.Read))  {
        GoogleWebAuthorizationBroker.Folder = "Tasks.Auth.Store";
        credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
        GoogleClientSecrets.Load(stream).Secrets,
        new[] { DriveService.Scope.Drive,
                DriveService.Scope.DriveFile },
        "user",
        CancellationToken.None,
        new FileDataStore("Drive.Auth.Store")).Result;
        }  
