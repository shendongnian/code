    var folder = System.Web.HttpContext.Current.Server.MapPath("/App_Data/MyGoogleStorage");
    UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
       new ClientSecrets
       {
           ClientId = System.Configuration.ConfigurationManager.AppSettings["GDriveClientId"],//Get   ClientID from web.config.
           ClientSecret =   System.Configuration.ConfigurationManager.AppSettings["GDriveClientSecret"]//Get ClientSecret from   web.config.
       },
       new[] { DriveService.Scope.Drive },
       System.Configuration.ConfigurationManager.AppSettings["GDriveCreatedByUser"],//Get UserName from   web.config.
       CancellationToken.None,
       new FileDataStore(folder)).Result;
    return credential;
