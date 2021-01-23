    class FileNameCompare : System.Collections.Generic.IEqualityComparer<System.IO.FileInfo>
    {
        public FileNameCompare() { }
        public bool Equals(System.IO.FileInfo file1, System.IO.FileInfo file2)
        {
            return file1.Name == file2.Name && file1.Length == file2.Length;
        }
        public int GetHashCode(System.IO.FileInfo fileInfo)
        {
            string fileString = String.Format("{0}{1}", fileInfo.Name, fileInfo.Length);
            return fileString.GetHashCode();
        }
    }
