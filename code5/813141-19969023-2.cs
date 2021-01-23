    public class Folder
    {
        public Folder(string displayName)
        {
            ImageSource = DataSource.Folder1;
            Children = new List<Folder>();
            ItemCountColor = "Blue";
            DisplayName = displayName;
        }
        public Folder(string displayName, int itemCount): this(displayName)
        {
            ItemCount = itemCount;
        }
        public string DisplayName { get; set; }
        public int ItemCount { get; set; }
        public List<Folder> Children { get; set; }
        public string ItemCountColor { get; set; }
        public string ImageSource { get; set; } 
    }
