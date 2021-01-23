    using (ShimsContext.Create())
    {
        Microsoft.Win32.Fakes.ShimRegistryKey.AllInstances.CreateSubKeyStringRegistryKeyPermissionCheck = (key, newSubKeyName, permissionCheck) =>
        {
            var newSubKey = new Microsoft.Win32.Fakes.ShimRegistryKey();
            newSubKey.NameGet = () => Path.Combine(key.Name, newSubKeyName); // All I care about for now is the name of the new subkey
            return newSubKey; 
        };
    }
