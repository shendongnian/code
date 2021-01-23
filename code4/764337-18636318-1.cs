      using (client = Amazon.AWSClientFactory.CreateAmazonS3Client(accessKey, secretKey))
                        {
    
                             var stream = new System.IO.MemoryStream();
                             originalBMP.Save(stream, ImageFormat.Bmp);
                             stream.Position = 0;
                             
                            PutObjectRequest request = new PutObjectRequest();
                            request.InputStream = stream;
                            request.BucketName="MyBucket";
                            request.CannedACL = S3CannedACL.PublicRead;
                            request.Key = "images/" + filename;
                            S3Response response = client.PutObject(request);
                        }
