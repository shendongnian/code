    public static bool IsFileDescendantOfDirectory(FileInfo fileInfo, DirectoryInfo directoryInfo)
    {
        DirectoryInfo dir = fileInfo.Directory;
        while (dir != null)
        {
            if (dir.FullName.Equals(directoryInfo.FullName, StringComparison.OrdinalIgnoreCase))
                return true;
            dir = dir.Parent;
        }
        return false;
    }
