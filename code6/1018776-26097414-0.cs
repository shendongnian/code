    public CloudBlobContainer GetContainerReference(string containerName)
    {
        CommonUtility.AssertNotNullOrEmpty("containerName", containerName);
        return new CloudBlobContainer(containerName, this);
    }
