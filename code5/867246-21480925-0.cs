    public static Version GetInstalledVersionFromRegistry()
    {
        return Util.GetInstalledVersionFromRegistry();
    }
    
    public static Version GetVersionFromRemote()
    {
        return Util.GetAvailableVersionFromRemote();
    }
    
    public static bool IsUpdateAvailable()
    {
        Version installedVersion = GetInstalledVersionFromRegistry();
        Version availableVersion = GetVersionFromRemote();
    
        bool isRemoteVersionNewer = IsVersionNewer(installedVersion, availableVersion);
    
        return isRemoteVersionNewer;
    }
