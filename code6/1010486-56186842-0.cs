c#
...
public void UploadFile()
{
    var client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1);
    var transferUtility = new TransferUtility(client);
    try
    {
        TransferUtilityUploadRequest transferUtilityUploadRequest = new TransferUtilityUploadRequest
        {
            BucketName = bucketName,
            Key = keyName,
            FilePath = filePath,
            ContentType = "text/plain"
        };
        transferUtility.Upload(transferUtilityUploadRequest); // use UploadAsync if possible
    }
...
More info [here](https://docs.aws.amazon.com/AmazonS3/latest/dev/HLuploadFileDotNet.html).
