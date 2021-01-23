                CloudStorageAccount storageAccount = new CloudStorageAccount(new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(accountName, accountKey), true);
                var blobClient = storageAccount.CreateCloudBlobClient();
                ServiceProperties blobServiceProperties = new ServiceProperties();
                blobServiceProperties.Cors.CorsRules.Add(new CorsRule(){
                    AllowedHeaders = new List<string>() {"*"},
                    ExposedHeaders = new List<string>() {"*"},
                    AllowedMethods = CorsHttpMethods.Post | CorsHttpMethods.Put | ... Other Allowed Methods,
                    AllowedOrigins = new List<string>() {"http://yourdomain.com", "https://yourdomain.com", "blah", "blah", "blah"},
                    MaxAgeInSeconds = 3600,
                });
                blobClient.SetServiceProperties(blobServiceProperties);
