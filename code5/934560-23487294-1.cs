    void TryScanSubKey(RegistryKey key)
    {
        try
        {
            ScanSubKey(Registry.ClassesRoot);
        } 
        catch (Exception ex)
        {
            Debug.WriteLine("The following error occurred opening a registry key: " + ex.Message);
        }
    }
