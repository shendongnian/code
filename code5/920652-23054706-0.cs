    class FileInfo {
        public string Name { get; set; }
        public string Ext { get; set; }
        public int Size { get; set; }
        public DateTime Created { get; set; }
        public FileInfo(string name, string ext, int size, DateTime created) {
            Name = name;
            Ext = ext;
            Size = size;
            Created = created;
        }
    }
