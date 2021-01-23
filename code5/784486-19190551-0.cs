        [Test]
        public void UploadMemoryFile()
        {
            var config = CloudConfigStorage.GetAdminConfig();
            string bucketName = config.BucketName;
            string clientAccessKey = config.ClientAccessKey;
            string clientSecretKey = config.ClientSecretKey;
            string path = Path.GetFullPath(@"dummy.txt");
            File.WriteAllText(path, DateTime.Now.ToLongTimeString());
            using (var client = AWSClientFactory.CreateAmazonS3Client(clientAccessKey, clientSecretKey))
            using (var transferUtility = new TransferUtility(client))
            {
                var request = new TransferUtilityUploadRequest
                {
                    BucketName = bucketName,
                    Key = "memory.txt",
                    InputStream = new MemoryStream(File.ReadAllBytes(path))
                };
                transferUtility.Upload(request);
            }
        }   
