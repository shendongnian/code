    public static IEnumerable<FileEntry> GetAllFiles(Folder folder)
    {
        foreach(var file in folder.Files)
        {
            yield return file;
        }
        foreach(var nestedFolder in folder.ChildFolders)
        {
            foreach(var file in GetAllFiles(nestedFolder))
            {
                yield return file;
            }
        }
    }
