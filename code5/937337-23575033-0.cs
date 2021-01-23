    public void DeleteFiles(string path, bool recursive, string searchPattern = null)
    {
        var entries = searchPattern == null ? Directory.EnumerateFileSystemEntries(path) : Directory.EnumerateFileSystemEntries(path, searchPattern);
        foreach(string entry in entries)
        {
            try
            {
                FileAttributes attr = File.GetAttributes(entry);
                //detect whether its a directory or file
                bool isDir = (attr & FileAttributes.Directory) == FileAttributes.Directory;
                if(!isDir)
                    File.Delete(entry);
                else if(recursive)
                    DeleteFiles(entry, true, searchPattern);
            }
            catch
            {
                //ignore
            }
        }
    }
