    public bool SaveFile(S3Folder folder, string customFolder, string fileName, Stream stream, bool publicFile)
        {
            // Validações
            if (string.IsNullOrEmpty(fileName) || stream == null)
                return false;
            AmazonS3Config S3Config = new AmazonS3Config()
            {
                ServiceURL = "s3.amazonaws.com",
                CommunicationProtocol = Protocol.HTTP,
                RegionEndpoint = region
            };
            using (var s3Client = new AmazonS3Client(accessKey, secretKey, S3Config))
            {
                
                var request = new PutObjectRequest();
                request.BucketName = bucketName;
                request.InputStream = stream;
                if (!string.IsNullOrEmpty(customFolder))
                    request.Key = GetFolder(folder) + "/" + customFolder + "/" + fileName;
                else
                    request.Key = GetFolder(folder) + "/" + fileName;
                if (!publicFile)
                    request.CannedACL = S3CannedACL.Private;
                else
                    request.CannedACL = S3CannedACL.PublicRead;
                s3Client.PutObject(request);
                return true;
            }
        }
