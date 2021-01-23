    private class FileInfoComparer : IEqualityComparer<FileInfo>
    {
        public bool Equals(FileInfo x, FileInfo y)
        {
            return x == null ? y == null : (x.Name.Equals(y.Name, StringComparison.CurrentCultureIgnoreCase) && x.Length == y.Length);
        }
        public int GetHashCode(FileInfo obj)
        {
            return obj.GetHashCode();
        }
    }
    sFiles = sFiles.Except(dFiles, new FileInfoComparer()).ToList();
