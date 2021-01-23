    DriveInfo[] loadedDrives = DriveInfo.GetDrives();
    List<DriveInfo> deviceInfo = new List<DriveInfo>();
    foreach (DriveInfo ld in loadedDrives)
    {
        if (ld.DriveType == DriveType.Removable)
        {
            if (ld.IsReady == true)
            {             
                    deviceInfo.Add(ld);              
            }
        }
    }
    foreach (DriveInfo st in deviceInfo)
    {
         //can write whatever you want now
    }
