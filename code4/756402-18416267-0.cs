    public static string FindFullPath(string path, string folderName)
    {
    	if (string.IsNullOrWhiteSpace(folderName) || !Directory.Exists(path))
    	{
    		return null;
    	}
    	var di = new DirectoryInfo(path);
    	return findFullPath(di, folderName);
    }
    private static string findFullPath(DirectoryInfo directoryInfo, string folderName)
    {
    	if (folderName.Equals(directoryInfo.Name, StringComparison.InvariantCultureIgnoreCase))
    	{
    		return directoryInfo.FullName;
    	}
    	try
    	{
    		var subDirs = directoryInfo.GetDirectories();
    		return subDirs.Select(subDir => findFullPath(subDir, folderName)).FirstOrDefault(fullPath => fullPath != null);
    	}
    	catch
    	{
            // DirectoryNotFound, Security, UnauthorizedAccess
    		return null;
    	}
    }
