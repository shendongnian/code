    public class Node
    {
      public readonly ReadOnlyCollection<Node> Children;
      public Node(IEnumerable<Node> children)
      {
        Children = new ReadOnlyCollection<Node>(children);
      }
    }
