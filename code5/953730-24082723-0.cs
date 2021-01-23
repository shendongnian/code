    public class File
    {
        private Folder _folder;
        [Key, Column(Order = 0)]
        public string FolderName { get; set; }
        [Key, Column(Order = 1)]
        public DateTime FileName { get; set; }
    
        [ForeignKey("FolderName")]
        public virtual Folder Folder
        {
            get { return _folder; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                _folder = value;
                FolderName = _folder.Name;
            }
        }
    }
