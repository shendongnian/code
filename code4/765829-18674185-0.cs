    public static IEnumerable<DirectoryInfo> GetSelectedDirectoryInformation(String argDirectoryName, IEnumerable<String> argExcludeDrives)
    {
       foreach(DriveInfo di in DriveInfo.GetDrives())
       {
          if ((argExcludedDrives == null) || (!argExcludedDrives.Contains(di.Name)))
          {
             string directory = Path.Combine(di.Name,argDirectoryName); 
             if (DirectoryExists(directory))
             {
                yield return new DirectoryInfo(directory);
             }
          }
       }
    }
