    public bool TryOpenRegKey(RegistryKey regKey, string subKey = string.Empty)
    {
      try
      {
        if (string.IsNullOrWhiteSpace(subKey))
          ScanSubKey(regKey);
        else
          ScanSubKey(regKey.OpenSubKey(subKey));
      }
      catch(Exception ex)
      {
        Debug.WriteLine("The following error occurred opening a registry key: " + ex.Message);
      }
    }
