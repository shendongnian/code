    public class Node
    {
        public Node()
        {
            Child = new List<Node>();
            Attributes = new List<NodeAttribute>();
        }
        public string Text { get; set; }
        public List<Node> Child { get; set; }
        public List<NodeAttribute> Attributes { get; set; }
        public bool IsLeafNode { get; set; }
        public bool HasAttributes { get; set; }
        CompositeCollection comp;
        public CompositeCollection ChildAndAttributes
        {
            get
            {
                if (comp == null)
                {
                    comp = new CompositeCollection();
                    comp.Add(new CollectionContainer() { Collection = Child });
                    comp.Add(new CollectionContainer() { Collection = Attributes });
                }
                return comp;
            }
        }
    }
