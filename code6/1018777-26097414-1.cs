    internal CloudBlobContainer(string containerName, CloudBlobClient serviceClient) : this(new BlobContainerProperties(), new Dictionary<string, string>(), containerName, serviceClient)
    {
    }
    internal CloudBlobContainer(BlobContainerProperties properties, IDictionary<string, string> metadata, string containerName, CloudBlobClient serviceClient)
    {
        this.StorageUri = NavigationHelper.AppendPathToUri(serviceClient.StorageUri, containerName);
        this.ServiceClient = serviceClient;
        this.Name = containerName;
        this.Metadata = metadata;
        this.Properties = properties;
    }
