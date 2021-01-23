    newBlob.FetchAttributes();
    if (newBlob.Metadata.ContainsKey(StorageManager.IsLive))
    {
    	newBlob.Metadata[StorageManager.IsLive] = "N";
    }
    else
    {
    	newBlob.Metadata.Add(new KeyValuePair<string, string>(StorageManager.IsLive, "N"));
    } 
