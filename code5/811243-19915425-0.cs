    ServiceAccountCredential.Initializer initializer =
        new ServiceAccountCredential.Initializer(serviceAccountEmail)
        {
            Scopes = serviceAccountScope,
            User = "user1@myDomain.com"
        }.FromCertificate(certificate);
    
    var service1 = new DriveService(new BaseClientService.Initializer()
    {
        HttpClientInitializer = new ServiceAccountCredential(initializer),
        ApplicationName = appName,
    });
    
    initializer.User = "user2@myDomain.com"
    var service2 = new DriveService(new BaseClientService.Initializer()
    {
        HttpClientInitializer = new ServiceAccountCredential(initializer),`
        ApplicationName = appName,
    });
