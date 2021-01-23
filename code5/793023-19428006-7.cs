    public class Path
    {
        public string Name { get; set; }
        public bool IsLeaf { get; set; }
        public ObservableCollection<Path> Children { get; set; }
    }
