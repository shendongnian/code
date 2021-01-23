    public void uploadBytesToBlobWithMimeAndStorageCreds(string theFolder, string theFileName, byte[] videoBytes, string theMimeType)
    {
    	CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnection"].ConnectionString);
    
    	CloudBlobClient client = storageAccount.CreateCloudBlobClient;
    	CloudBlobContainer container = client.GetContainerReference(theFolder);
    
    	CloudBlob blob = container.GetBlobReference(theFileName);
    	blob.UploadByteArray(theBytes);
    	blob.Properties.CacheControl = "max-age=3600, must-revalidate";
    	blob.Properties.ContentType = theMimeType; // e.g. "video/mp4"
    	blob.SetProperties();
    
    }
