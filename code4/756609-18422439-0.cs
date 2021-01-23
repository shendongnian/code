    public static void DeleteDirectoryRecursively(this IsolatedStorageFile storageFile, String dirName)
    {
        String pattern = dirName + @"\*";
        String[] files = storageFile.GetFileNames(pattern);
        foreach (var fName in files)
        {
            storageFile.DeleteFile(Path.Combine(dirName, fName));
        }
        String[] dirs = storageFile.GetDirectoryNames(pattern);
        foreach (var dName in dirs)
        {
            DeleteDirectoryRecursively(storageFile, Path.Combine(dirName, dName));
        }
        storageFile.DeleteDirectory(dirName);
    }
