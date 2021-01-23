    public static void DeleteEmptyFolders(string rootFolder)
    {
        foreach (string subFolder in Directory.EnumerateDirectories(rootFolder))
            DeleteEmptyFolders(subFolder);
        DeleteFolderIfEmpty(rootFolder);
    }
    public static void DeleteFolderIfEmpty(string folder)
    {
        if (!Directory.EnumerateFileSystemEntries(folder).Any())
            Directory.Delete(folder);
    }
