    /// <summary>
    /// Returns true if the application is detected to be running in an Azure role (tested for web roles).
    /// </summary>
    public static bool RunningInAzure
    {
      get
      {
        try
        {
          string sCurrentDrive = Path.GetPathRoot(AppDomain.CurrentDomain.BaseDirectory);
          if (!string.IsNullOrEmpty(sCurrentDrive))
            return File.Exists(Path.Combine(sCurrentDrive, "RoleModel.xml"));
        }
        catch { }
        return false;
      }
    }
