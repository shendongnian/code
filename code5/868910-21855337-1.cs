    ServerFiles.ForEachAsync(async file =>
    {
        string sFileName = File.Uri.LocalPath.ToString();
        CloudBlockBlob oBlob = BiActionscontainer.GetBlockBlobReference(sFileName.Replace("/" + Container + "/", ""));
    
        var ms = new MemoryStream();
        BlobRequestOptions f = new BlobRequestOptions();
        await oBlob.DownloadToStreamAsync(ms);
    
        ms.Position = 0;
        lock (lockObject)
        {
             using (var file = new FileStream(ResultPath, FileMode.Append, FileAccess.Write))
             {
                  await ms.CopyToAsync(file);
             }
        }
    });
