    public static void DirectoryCopy(string sourceDirPath, string destDirName, bool isCopySubDirs)
    {
        // Get the subdirectories for the specified directory.
        DirectoryInfo directoryInfo = new DirectoryInfo(sourceDirPath);
        DirectoryInfo[] directories = directoryInfo.GetDirectories();
        if (!directoryInfo.Exists)
        {
            throw new DirectoryNotFoundException("Source directory does not exist or could not be found: "
                + sourceDirPath);
        }
        DirectoryInfo parentDirectory = Directory.GetParent(directoryInfo.FullName);
        destDirName = System.IO.Path.Combine(parentDirectory.FullName, destDirName);
        // If the destination directory doesn't exist, create it. 
        if (!Directory.Exists(destDirName))
        {
            Directory.CreateDirectory(destDirName);
        }
        // Get the files in the directory and copy them to the new location.
        FileInfo[] files = directoryInfo.GetFiles();
        foreach (FileInfo file in files)
        {
            string tempPath = System.IO.Path.Combine(destDirName, file.Name);
            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
            }
            file.CopyTo(tempPath, false);
        }
        // If copying subdirectories, copy them and their contents to new location using recursive  function. 
        if (isCopySubDirs)
        {
            foreach (DirectoryInfo item in directories)
            {
                string tempPath = System.IO.Path.Combine(destDirName, item.Name);
                DirectoryCopy(item.FullName, tempPath, isCopySubDirs);
            }
        }
    }
