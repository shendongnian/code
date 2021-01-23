    var folder = System.Web.HttpContext.Current.Server.MapPath("/App_Data/MyGoogleStorage");
    UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
       new ClientSecrets
       {
           ClientId = "PutYourClientIdHere",
           ClientSecret = "PutYourClientSecretHere"
       },
       new[] { DriveService.Scope.Drive },
       "user",
       CancellationToken.None,
       new FileDataStore(folder)).Result;
    return credential;
