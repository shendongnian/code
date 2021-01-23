    string remoteDirName = @"/Public/WS";
    string targetDir = @"C:\Users\Michael\";
    var remoteDir = dropBoxStorage.GetFolder(remoteDirName);
    
    public static DownloadFolder(CloudStorage dropBoxStorage,ICloudDirectoryEntry remoteDir, string targetDir)
    {
    	
    	foreach (ICloudFileSystemEntry fsentry in remoteDir)
    	{
    		if (fsentry is ICloudDirectoryEntry)
    		{
    			DownloadFolder(dropBoxStorage, fsentry, Path.Combine(targetDir, fsentry.Name));
    		}
    		else
    		{
    			dropBoxStorage.DownloadFile(remoteDir,fsentry.Name,Path.Combine(targetDir, fsentry.Name));
    		}
    	}
    }
