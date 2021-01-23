      public class leaf
    {
        public string name { get; set; }
    }
    public class node 
    {
        public string name { get; set; }
        public ObservableCollection<node> nodeList = new ObservableCollection<node>();
        public ObservableCollection<leaf> leafList = new ObservableCollection<leaf>();
        public ObservableCollection<node> prop_nodeList { get { return nodeList; } set { nodeList = value; } }
        public ObservableCollection<leaf> prop_leafList { get { return leafList; } set { leafList = value; } }
        public ObservableCollection<object> Children
        {
            get
            {
                var children = prop_nodeList.OfType<object>();
                return new ObservableCollection<object>(children.Concat(prop_leafList.OfType<object>()));
            }
        }
    }
    public class NodesData 
    {
        public ObservableCollection<node> RootSource { get; set; }
        public NodesData()
        {
            var rootNode = new node() { name = ">>>Head Node<<<<" };
           
            var b = new node() { name = "b" };
            var c = new node() { name = "c" };
            var a = new node()
                        {
                            name = "a",
                            prop_nodeList = new ObservableCollection<node>() { b, c },
                            prop_leafList = new ObservableCollection<leaf>() { new leaf() { name = "a1" }, new leaf() { name = "a2" } }
                        };
            rootNode.prop_nodeList = new ObservableCollection<node>() { b, a };
            RootSource = new ObservableCollection<node>() { rootNode };
        }
    }
