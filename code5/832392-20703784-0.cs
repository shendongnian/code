        public Stream DownloadS3Object(string awsBucketName, string keyName)
        {
            using (var client = Amazon.AWSClientFactory.CreateAmazonS3Client())
            {
                Stream imageStream = new MemoryStream();
                GetObjectRequest request = new GetObjectRequest { BucketName = awsBucketName, Key = keyName };
                using (GetObjectResponse response = client.GetObject(request))
                {
                    response.ResponseStream.CopyTo(imageStream);
                }
                imageStream.Position = 0;
                // Clean up temporary file.
                // System.IO.File.Delete(dest);
                return imageStream;
            }
        }
