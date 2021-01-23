    private static void InitializeCors()
    {
      // CORS should be enabled once at service startup
      // Given a BlobClient, download the current Service Properties 
      ServiceProperties blobServiceProperties = BlobClient.GetServiceProperties();
      ConfigureCors(blobServiceProperties);
      BlobClient.SetServiceProperties(blobServiceProperties);
    }
    private static void ConfigureCors(ServiceProperties serviceProperties)
    {
      serviceProperties.Cors = new CorsProperties();
      serviceProperties.Cors.CorsRules.Add(new CorsRule()
      {
         AllowedHeaders = new List<string>() { "*" },
         AllowedMethods = CorsHttpMethods.Get | CorsHttpMethods.Head,
         AllowedOrigins = new List<string>() { "*" },
         ExposedHeaders = new List<string>() { "*" },
         MaxAgeInSeconds = 1800 // 30 minutes
     });
    }
