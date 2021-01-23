    class FileItem
    {
        string FullName { get; set; }
        public FileItem(string file)
        {
            FullName = file;
        }
        public override string ToString()
        {
            return Path.GetFileNameWithoutExtension(FullName);
        }
    }
