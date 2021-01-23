    public void DuplicateFileInCloud(string original, string destination)
    {
        try
        {
            CopyObjectRequest request = new CopyObjectRequest();
    
            if (original.StartsWith("http"))
            {
                // example: http://jk-v30.s3.amazonaws.com/PredefinedFiles/Favicons/002.ico
                string bucket = getBucketNameFromUrl(original), // i.e. jk-v30
                        key = getKeyFromUrl(original);          // the path to your file: PredefinedFiles/Favicons/002.ico
    
                request.WithSourceBucket(bucket);
                request.WithSourceKey(key);
            }
            else
            {
                // same bucket: copy/paste operation
                request.WithSourceBucket(this.bucketName);
                request.WithSourceKey(original);
            }
    
            request.WithDestinationBucket(this.bucketName);
            request.WithDestinationKey(destination);
            request.CannedACL = S3CannedACL.PublicRead; // one way of setting public headers - see other below
    
            using (AmazonS3 client = Amazon.AWSClientFactory.CreateAmazonS3Client(this.accessKey, this.secretAccessKey))
            {
                S3Response response = client.CopyObject(request);
                response.Dispose();
            }
        }
        catch (AmazonS3Exception s3Exception)
        {
            throw s3Exception;
        }
    }
