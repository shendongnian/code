    using System.Management;
     
    public static string GetPath(string uncPath)
    {
      try
      {
        // remove the "\\" from the UNC path and split the path
        uncPath = uncPath.Replace(@"\\", "");
        string[] uncParts = uncPath.Split(new char[] {'\\'}, StringSplitOptions.RemoveEmptyEntries);
        if (uncParts.Length < 2)
          return "[UNRESOLVED UNC PATH: " + uncPath + "]";
        // Get a connection to the server as found in the UNC path
        ManagementScope scope = new ManagementScope(@"\\" + uncParts[0] + @"\root\cimv2");
        // Query the server for the share name
        SelectQuery query = new SelectQuery("Select * From Win32_Share Where Name = '" + uncParts[1] + "'");
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
      
        // Get the path
        string path = string.Empty;
        foreach (ManagementObject obj in searcher.Get())
        {
          path = obj["path"].ToString();
        }
     
        // Append any additional folders to the local path name
        if (uncParts.Length > 2)
        {
          for (int i = 2; i < uncParts.Length; i++)
            path = path.EndsWith(@"\") ? path + uncParts[i] : path + @"\" + uncParts[i];
        }
     
        return path;
      }
      catch (Exception ex)
      {
        return "[ERROR RESOLVING UNC PATH: " + uncPath + ": "+ex.Message+"]";
      }
    }
