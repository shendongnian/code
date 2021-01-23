    // Create a client
    AmazonS3Client client = new AmazonS3Client();
     
    // List all objects
    ListObjectsRequest listRequest = new ListObjectsRequest
    {
        BucketName = "SampleBucket",
    };
     
    ListObjectsResponse listResponse;
    do
    {
        // Get a list of objects
        listResponse = client.ListObjects(listRequest);
        foreach (S3Object obj in listResponse.S3Objects)
        {
            Console.WriteLine("Object - " + obj.Key);
            Console.WriteLine(" Size - " + obj.Size);
            Console.WriteLine(" LastModified - " + obj.LastModified);
            Console.WriteLine(" Storage class - " + obj.StorageClass);
        }
     
        // Set the marker property
        listRequest.Marker = listResponse.NextMarker;
    } while (listResponse.IsTruncated);
