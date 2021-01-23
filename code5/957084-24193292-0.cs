    public static void Save()
    {
        string[] drives = Directory.GetLogicalDrives();
        foreach(string drive in drives)
        {
            DriveInfo diagnose = new DriveInfo(drive);
            if(diagnose.isReady && diagnose.VolumeLabel == @"Backup" && diagnose.DriveType == DriveType.Fixed)
                  ^^Make sure the drive is ready before examining properties
            {
                CopyDirectory(
                    ConfigurationManager.AppSettings[@"Source"],
                    ConfigurationManager.AppSettings[@"Destination"]);
            }
        }
     }
