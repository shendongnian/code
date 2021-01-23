    public List<FileInfo> GetFiles(string path, params string[] extensions)
    {
        List<FileInfo> list = new List<FileInfo>();
        foreach (string ext in extensions)
            list.AddRange(new DirectoryInfo(path).GetFiles("*" + ext).Where(p =>
                  p.Extension.Equals(ext,StringComparison.CurrentCultureIgnoreCase))
                  .ToArray());
        return list;
    }
