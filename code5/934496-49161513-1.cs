    CloudStorageAccount backupStorageAccount = CloudStorageAccount.Parse(YOUR_CON_STRING);
    var backupBlobClient = backupStorageAccount.CreateCloudBlobClient();
    var backupContainer = backupBlobClient.GetContainerReference("CONTAINER");
    var blobs = backupContainer.ListBlobs().OfType<CloudBlockBlob>().ToList();
    foreach (var blob in blobs)
    {
        string bName = blob.Name;
        long bSize = blob.Properties.Length;
        string bModifiedOn = blob.Properties.LastModified.ToString();        
    }
