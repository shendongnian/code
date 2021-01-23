    // Code that gets the LastUpdateInfo from an native or custom domain object
    public void GetLastUpdateInfo(object domainObject)
    {
        // Get the service
        ILastUpdateInfoFactory lastUpdateInfoFactory = CoreSystem.GetService<ILastUpdateInfoFactory>(domainObject);
        // Get the LastUpdateInfo
        LastUpdateInfo lastUpdateInfo = lastUpdateInfoFactory.GetLastUpdateInfo(domainObject);
        // Process the result
        PetrelLogger.InfoOutputWindow(string.Format("Last updated at: {0} by {1}.",
                                                lastUpdateInfo.Time, lastUpdateInfo.UserName));
    }
