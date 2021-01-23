    String serviceAccountEmail = "539621478854-imkdv94bgujcom228h3ea33kmkoefhil@developer.gserviceaccount.com";
    var certificate = new X509Certificate2(@"C:\Users\linda_l\Documents\GitHub\GoogleBigQueryServiceAccount\GoogleBigQueryServiceAccount\key.p12", "notasecret", X509KeyStorageFlags.Exportable);
    
    ServiceAccountCredential credential = new ServiceAccountCredential(
           new ServiceAccountCredential.Initializer(serviceAccountEmail)
              {
               Scopes = new[] { BigqueryService.Scope.DevstorageReadOnly }
              }.FromCertificate(certificate));
    
            // Create the service.
    var service = new BigqueryService(new BaseClientService.Initializer()
          {
           HttpClientInitializer = credential,
           ApplicationName = "BigQuery API Sample",
           });
