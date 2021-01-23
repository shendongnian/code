    AmazonS3Config config = new AmazonS3Config();
    config.ServiceURL = serviceUrl;//amazon s3 URL		                      
    config.UseHttp = true;
    config.RegionEndpoint =Amazon.RegionEndpoint.APNortheast1;//your region
    AmazonS3Client client = new AmazonS3Client(accessKey,
        secretAccessKey, config);
    TransferUtility transferUtility = new TransferUtility(client);
    TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();
    request.BucketName = s3Bucket;
    request.FilePath = filePath;//local file path 
    //Test that the path is correct
    UIImage image = UIImage.FromFile(filePath);
    System.Threading.CancellationToken canellationToken = new System.Threading.CancellationToken();
    await transferUtility.UploadAsync(request, canellationToken);
