    void TryScanSubKey(RegistryKey key)
    {
        try
        {
            ScanSubKey(key);
        } 
        catch (Exception ex)
        {
            Debug.WriteLine("The following error occurred opening a registry key: " + ex.Message);
        }
    }
