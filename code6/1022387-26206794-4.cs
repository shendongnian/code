    public class QueueItem {
      public Node Node { get; private set; }
      public List<Edge> Visited { get; private set; }
      public QueueItem(Node node, List<Edge> visited) {
        Node = node;
        Visited = visited;
      }
    }
