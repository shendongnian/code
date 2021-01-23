    public Uri UploadBlob(string path, string fileName, string content)
    {
        var cloudBlobContainer = cloudBlobClient.GetContainerReference(path);
        cloudBlobContainer.CreateIfNotExist();
     
        var blob = cloudBlobContainer.GetBlobReference(fileName);
        blob.UploadText(content);
     
        return blob.Uri;
    }
