    using Google.Apis.Auth.OAuth2;
    using System.Security.Cryptography.X509Certificates;
    using Google.Apis.Services;
    using Google.Apis.Drive.v2;  
    var serviceAccountEmail = "539621478859-imkdv94bgujcom228h3ea33kmkoefhil@developer.gserviceaccount.com";
    ServiceAccountCredential certificate = new X509Certificate2(@"C:\dev\GoogleDriveServiceAccount\key.p12", "notasecret", X509KeyStorageFlags.Exportable);
            
    ServiceAccountCredential credential = new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(serviceAccountEmail)
               {
                   Scopes = new[] { DriveService.Scope.DriveReadonly }
               }.FromCertificate(certificate));
    // Create the service.
    var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Drive API Sample",
            });
