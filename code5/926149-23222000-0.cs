    AmazonS3Client client = new AmazonS3Client(<awsAccessKeyId>, <awsScrectKey>, RegionEndpoint.APNortheast1);
            string[] files = Directory.GetFiles(@"uploadFolder");
            int count = 1;
            foreach (string file in files)
            {
                if (count % 8 == 0)
                {
                    Console.WriteLine("upload " + count.ToString() + "/" + files.Length.ToString() + ".." + file.Replace("AWS\\", ""));
                    PutObjectRequest requestd = new PutObjectRequest
                    {
                        BucketName = "yourBucketName",
                        Key = file.Replace("AWS\\" , ""),
                    };
                    using (FileStream stream = new FileStream(file, FileMode.Open))
                    {
                        requestd.InputStream = stream;
                        // Put object
                        PutObjectResponse response = client.PutObject(requestd);
                    }
                    // Set Canned ACL (PublicRead) for an existing item
                    client.SetACL(new SetACLRequest
                    {
                        BucketName = "yourBucketName",
                        Key = file.Replace("AWS\\", ""),
                        CannedACL = S3CannedACL.PublicRead
                    });
                }
                count++;
            }
