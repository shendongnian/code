    var drives = DriveInfo.GetDrives().Where(x => x.DriveType == DriveType.Removable);
    
    List<FileInfo[]> pictureHandles = new List<FileInfo[]>();
    
    // Find all files of a certain type on each drive
    foreach(var drive in drives)
    {
        pictureHandles.Add(
                    new DirectoryInfo(drive.Name)
                    .GetFiles("*.jpg",SearchOption.AllDirectories)
                    .ToArray());
    }
    
    // Do stuff with pictureHandles, then use File.Delete
    foreach(FileInfo[] files in pictureHandles)
    {
        for (int i = 0; i < files.Length; i++)
        {
            try 
            { 
                File.Delete(files[i].FullName); 
            }
            catch(Exception ex)
            {
                // Failed to delete
            }
        }
    }
