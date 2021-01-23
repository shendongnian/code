    var client = AWSClientFactory.CreateAmazonKeyManagementServiceClient();
    using (var algorithm = new KMSAlgorithm(client, "CustomerMasterKeyIdOrAlias"))
    {
        var materials = new EncryptionMaterials(algorithm);
        var s3client = new AmazonS3EncryptionClient(materials);
    
        s3client.PutObject(new PutObjectRequest()
        {
            BucketName = "YourBucketName",
            Key = "YourKeyName",
            InputStream = new MemoryStream(Encoding.Default.GetBytes("Secret Message")),
        });
    }
    
    using (var algorithm = new KMSAlgorithm(client))
    {
        var materials = new EncryptionMaterials(algorithm);
        var s3client = new AmazonS3EncryptionClient(materials);
    
        var obj = s3client.GetObject(new GetObjectRequest()
        {
            BucketName = "YourBucketName",
            Key = "YourKeyName"
        });
    }
