    // Find removable disks
    var drives = DriveInfo.GetDrives().Where(x => x.DriveType == DriveType.Removable && x.IsReady);
    
    List<FileInfo[]> pictureHandles = new List<FileInfo[]>();
    
    // Find all files of a certain type on each drive
    foreach(var drive in drives)
    {
        pictureHandles.Add(
                    new DirectoryInfo(drive.Name)
                    .GetFiles("*.jpg",SearchOption.AllDirectories)
                    .ToArray());
    }
    
    // Do stuff with pictureHandles and identify
    // which drive is which camera using System.Management
