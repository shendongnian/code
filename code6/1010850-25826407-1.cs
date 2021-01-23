        private void AzureCors()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials("removed", "removed"), true);
            var blobClient = storageAccount.CreateCloudBlobClient();
            ServiceProperties blobServiceProperties = new ServiceProperties()
            {
                HourMetrics = null,
                MinuteMetrics = null,
                Logging = null,
            };
            blobServiceProperties.Cors.CorsRules.Add(new CorsRule()
            {
                AllowedHeaders = new List<string>() { "*" },
                AllowedMethods = CorsHttpMethods.Put | CorsHttpMethods.Get | CorsHttpMethods.Head | CorsHttpMethods.Post,
                AllowedOrigins = new List<string>() { "*" },
                ExposedHeaders = new List<string>() { "*" },
                MaxAgeInSeconds = 3600 // 30 minutes 
            });
            blobClient.SetServiceProperties(blobServiceProperties);
        }
