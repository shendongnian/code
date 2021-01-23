    public bool TryOpenRegKey(RegistryKey regKey, string subKey)
    {
      try
      {
        ScanSubKey(regKey.OpenSubKey(subKey));
      }
      catch(Exception ex)
      {
        Debug.WriteLine("The following error occurred opening a registry key: " + ex.Message);
      }
    }
