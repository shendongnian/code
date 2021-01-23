    public static FileInfo GetNewestFile(DirectoryInfo directory)
    {
        return directory.GetFiles()
            .Union(directory.GetDirectories().Select(d => GetNewestFile(d)))
            .MaxBy(f => (f == null ? DateTime.MinValue : f.LastWriteTime));
    }
