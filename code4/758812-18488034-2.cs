    public class leaf
        {
            public string name { get; set; }
        }
    public class node : leaf
    {
        public ObservableCollection<node> nodeList = new ObservableCollection<node>();
        public ObservableCollection<leaf> leafList = new ObservableCollection<leaf>();
        public ObservableCollection<node> prop_nodeList { get { return nodeList; } set { nodeList = value; } }
        public ObservableCollection<leaf> prop_leafList { get { return leafList; } set { leafList = value; } }
        public ObservableCollection<leaf> Children
        {
            get
            {
                return new ObservableCollection<leaf>(prop_nodeList.Concat(prop_leafList));
            }
        }
    }
    public class NodesData : node
    {
        public ObservableCollection<node> RootSource { get; set; }
        public NodesData()
        {
            name = ">>>Head Node<<<<";
            var b = new node() { name = "b" };
            var c = new node() { name = "c" };
            var a = new node()
                        {
                            name = "a",
                            prop_nodeList = new ObservableCollection<node>() { b, c },
                            prop_leafList = new ObservableCollection<leaf>() { new leaf() { name = "a1" }, new leaf() { name = "a2" } }
                        };
            prop_nodeList = new ObservableCollection<node>() { b, a };
            RootSource = new ObservableCollection<node>() { this };
        }
    }
