    blob.FetchAttributes();
    foreach (var attribute in blob.Metadata)
    {
        if (newBlob.Metadata.ContainsKey(attribute.Key))
        {
             newBlob.Metadata[attribute.Key] = attribute.Value;
        }
        else
        {
             newBlob.Metadata.Add(new KeyValuePair<string, string>(attribute.Key, attribute.Value));
        }
    }
    newBlob.SetMetadata();
