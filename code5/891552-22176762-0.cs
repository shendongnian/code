    public class Node
    {
        public Node(string value)
        {
            Value = value;
            Children = Enumerable.Empty<Node>();
        }
        public Node(string value, IEnumerable<Node> children)
        {
            Value = value;
            Children = children;
        }
        public string Value { get; private set; }
        public IEnumerable<Node> Children { get; private set; }
    }
