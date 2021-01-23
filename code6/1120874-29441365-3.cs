    public ActionResult Index()
    {
        return View();
    }
    // Other code
    [ChildActionOnly]
    public PartialViewResult _showBlobs(string containerName)
    {
        StorageCredentials credentials = new StorageCredentials(name, key);
        CloudStorageAccount storageAccount = new CloudStorageAccount(credentials, true);
        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        CloudBlobContainer storageContainer = blobClient.GetContainerReference(rootContainer);
     
        Models.SystemDesignModel blobsList = new Models.SystemDesignModel(storageContainer.ListBlobs(containerName, useFlatBlobListing: true));
 
        return PartialView(blobsList);
    }
