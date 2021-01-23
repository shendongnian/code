    public class Node
    {
        public string Title { get; set; }
        public ObservableCollection<Node> Children { get; set; }
    }
    public class MainViewModel
    {
        public ObservableCollection<Node> Nodes { get; set; }
        public MainViewModel()
        {
            Nodes = ... // load the structure here
        }
    }
