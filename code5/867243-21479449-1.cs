    ctor(Version installedVersion, Version availableVersion) {
        // Maybe store them in private fields.
    }
    
    public bool IsUpdateAvailable()
    {
        bool isRemoteVersionNewer = IsVersionNewer(installedVersion, availableVersion);
    
        return isRemoteVersionNewer;
    }
