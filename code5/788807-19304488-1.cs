    public class Node{
        public IEnumerable<Node> Children {get; private set;}
        public Node(IEnumerable<Node> children){
            Children = children.ToList();
        }
    }
