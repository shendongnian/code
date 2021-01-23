    Task.Run(async () =>
    {
        var s3 = new AmazonS3Client(Config.Instance.Aws.Credentials, Config.Instance.Aws.RegionEndpoint);
        var buckets = await s3.ListBucketsAsync();
    
        foreach (var s3Bucket in buckets.Buckets)
        {
            if (s3Bucket.BucketName.StartsWith("mybucket-"))
            {
                log.Information("Bucket => {BucketName}", s3Bucket.BucketName);
    
                ListObjectsResponse objects;
                try
                {
                    objects = await s3.ListObjectsAsync(s3Bucket.BucketName);
                }
                catch
                {
                    log.Error("Error getting objects. Bucket => {BucketName}", s3Bucket.BucketName);
                    continue;
                }
                
                // ForEachAsync (4 is how many tasks you want to run in parallel)
                await objects.S3Objects.ForEachAsync(4, async s3Object =>
                {
                    try
                    {
                        log.Information("Bucket => {BucketName} => {Key}", s3Bucket.BucketName, s3Object.Key);
                        await s3.DeleteObjectAsync(s3Bucket.BucketName, s3Object.Key);
                    }
                    catch
                    {
                        log.Error("Error deleting bucket {BucketName} object {Key}", s3Bucket.BucketName, s3Object.Key);
                    }
                });
    
                try
                {
                    await s3.DeleteBucketAsync(s3Bucket.BucketName);
                }
                catch
                {
                    log.Error("Error deleting bucket {BucketName}", s3Bucket.BucketName);
                }
            }
        }
    }).Wait();
