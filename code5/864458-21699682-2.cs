    /// <summary>
    /// Get from the registry all the drive guids
    /// </summary>
    static string[] GetDriveIds()
    {
        const string registryPath = @"Software\Microsoft\Windows\CurrentVersion\Explorer\BitBucket\Volume\";
        RegistryKey reg = Registry.CurrentUser.OpenSubKey(registryPath);
        string[] readIn = reg.GetSubKeyNames();
        string[] driveIds = new string[readIn.Length - 1];
        Array.Copy(readIn, 1, driveIds, 0, readIn.Length - 1); // The first item must be removed
        return driveIds;
    }
    
    /// <summary>
    /// Get and return the drive's recycle bin's MaxCapacity
    /// </summary>
    /// <param name="driveId">The guid of the specified drive</param>
    /// <returns>The size in mega bytes</returns>
    static int FindDriveCapacity(string driveId)
    {
        const string registryPath = @"Software\Microsoft\Windows\CurrentVersion\Explorer\BitBucket\Volume\{0}\";
        RegistryKey reg = Registry.CurrentUser.OpenSubKey(
            string.Format(registryPath, driveId));
        return (int)reg.GetValue("MaxCapacity", 0);
    }
