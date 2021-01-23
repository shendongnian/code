    CloudStorageAccount backupStorageAccount = CloudStorageAccount.Parse(blobConectionString);
    var backupBlobClient = backupStorageAccount.CreateCloudBlobClient();
    var backupContainer = backupBlobClient.GetContainerReference(container);
    // useFlatBlobListing is true to ensure loading all files in
    // virtual blob sub-folders as a plain list
    var list = backupContainer.ListBlobs(useFlatBlobListing: true);
    var listOfFileNames = new List<string>();
    foreach (var blob in blobs) {
      var blobFileName = blob.Uri.Segments.Last();
      listOfFileNames.Add(blobFileName); 
    }
    return listOfFileNames;
