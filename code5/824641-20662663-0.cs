    using (var s3Client = AWSClientFactory.CreateAmazonS3Client())
        {
            if(imageStream.CanSeek)
            {
                imageStream.Seek(0,SeekOrigin.Begin);
            }
            PutObjectRequest putObjectRequest = new PutObjectRequest( );
            putObjectRequest.BucketName = Settings.Default.AWSImageStore;
            putObjectRequest.CannedACL = S3CannedACL.PublicRead;
            putObjectRequest.Key = fileName;
            putObjectRequest.InputStream = imageStream;
            PutObjectResponse response = s3Client.PutObject(putObjectRequest);
            response.Dispose();
        }
