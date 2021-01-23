    String serviceAccountEmail = "YOUR SERVICE EMAIL HERE";
    
    var certificate = new X509Certificate2(@"PATH TO YOUR p12 FILE HERE", "notasecret", X509KeyStorageFlags.Exportable);
    
    ServiceAccountCredential credential = new ServiceAccountCredential(
        new ServiceAccountCredential.Initializer(serviceAccountEmail)
        {
            Scopes = new[] { Google.Apis.Storage.v1.StorageService.Scope.DevstorageFullControl }
        }.FromCertificate(certificate));
    
    Google.Apis.Storage.v1.StorageService ss = new Google.Apis.Storage.v1.StorageService(new Google.Apis.Services.BaseClientService.Initializer()
    {
        HttpClientInitializer = credential,
        ApplicationName = "YOUR APPLICATION NAME HERE",
    });
    
    var fileobj = new Google.Apis.Storage.v1.Data.Object()
    {
        Bucket = "YOUR BUCKET NAME HERE",
        Name = "file"
    };
    
    Stream stream = null;
    stream = new MemoryStream(img);
    
    Google.Apis.Storage.v1.ObjectsResource.InsertMediaUpload insmedia;
    insmedia = new Google.Apis.Storage.v1.ObjectsResource.InsertMediaUpload(ss, fileobj, "YOUR BUCKET NAME HERE", stream, "image/jpeg");
    insmedia.Upload();
