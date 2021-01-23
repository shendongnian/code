    public class Node
    {
        private Node _parent;
        private List<Node> _children = new List<Node>();
        public Node(Node parent)
        {
            _parent = parent
        }
        public ReadOnlyCollection<Node> Children
        {
            get { return _children.AsReadOnly(); }
        }
        public void AppendChild(Node child)
        {
            // your code
        }
    
        public void RemoveChild(Node child)
        {
            // your code
        }
    }
