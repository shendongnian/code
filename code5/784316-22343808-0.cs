    var PublicFolder = dropBoxStorage.GetFolder("/Public");
     if (PublicFolder != null && PublicFolder.ToList().Count > 0)
                    {
     DownloadFolder(dropBoxStorage, PublicFolder as ICloudDirectoryEntry, targetPath);
    }
 
    public static void DownloadFolder(CloudStorage dropBoxStorage, ICloudDirectoryEntry remoteDir, string targetDir)
        {
            foreach (var fof in remoteDir.ToList())
            {
    
                if (fof is ICloudDirectoryEntry)
                {
                    DirectoryInfo newDir = new DirectoryInfo(Path.Combine(targetDir, fof.Name));
                    if (!newDir.Exists)
                    {
                        Directory.CreateDirectory(Path.Combine(targetDir, fof.Name));
                    }
    
                    DownloadFolder(dropBoxStorage, fof as ICloudDirectoryEntry, Path.Combine(targetDir, fof.Name));
                }
                else
                {
                    dropBoxStorage.DownloadFile(remoteDir, fof.Name, Path.Combine(targetDir));
                }
    
            }
        }
