    public bool IsFileDescendantOfDirectory(DirectoryInfo directoryInfo, FileInfo fileInfo)
    {
        DirectoryInfo d = fileInfo.Directory;
        do
        {
            if (d.FullName.Equals(directoryInfo.FullName, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            d = d.Parent;
        }
        while(d != null);
        return false;
    }
