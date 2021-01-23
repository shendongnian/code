    BasicAWSCredentials awsCredentials = new BasicAWSCredentials(accessKeyHere, secretKeyHere);
    AmazonDynamoDBConfig adcConfig = new AmazonDynamoDBConfig()
    {
        ServiceURL = "s3.amazonaws.com",
        RegionEndpoint = Amazon.RegionEndpoint.EUWest1
    };
    AmazonDynamoDB client = new AmazonDynamoDBClient(awsCredentials, adcConfig);
