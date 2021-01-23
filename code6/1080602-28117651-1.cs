    public void Recurse(DirectoryInfo directory)
    {
        foreach (FileInfo fi in directory.GetFiles())
        {
            fi.Attributes = FileAttributes.Normal;
        }
        foreach (DirectoryInfo subdir in directory.GetDirectories())
        {
            Recurse(subdir);
        }
    }
