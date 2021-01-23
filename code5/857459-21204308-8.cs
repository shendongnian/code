    public class Node
    {    
        public Node(int id, params Node[] children)
        {
            Id = id;
            if (children.Any())
                Children = new List<Node>(children);
        }
        public int Id { get; set; }
        public List<Node> Children { get; set; }
    }
