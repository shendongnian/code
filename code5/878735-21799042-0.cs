    string initialscontainerPath = "signatures/initailsdata.png";
    
    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Microsoft.WindowsAzure.CloudConfigurationManager.GetSetting("StorageConnection"));
    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
    CloudBlobContainer container = blobClient.GetContainerReference(Request.Url.Host.ToLower().Replace(".", "-"));
    CloudBlockBlob blockBlob = container.GetBlockBlobReference(initialscontainerPath);
    blockBlob.Properties.ContentType = "image/png";
    
    byte[] initialsbytes = Convert.FromBase64String(initialsData);
    
    byte[] signaturebytes = Convert.FromBase64String(signatureData);
    
    CombineBitmaps(initialsbytes, signaturebytes);
