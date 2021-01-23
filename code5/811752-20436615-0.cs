    class Node
    {
        public Node()
        {
            Children = new List<Node>();
        }
        public string Name { get; set; }
        public List<Node> Children { get; set; }
    }
