    public class Node {
        public Vector3 position;
    }
    
    public class Path {
      private Dictionary<Node, Vector3> cameraPositions = new Dictionary<node,Vector3>();
      public List<Node> NodesInPath {get;}
    
      public Node AddNode(Node node, Vector3 cameraPosition);
      public Vector3 GetCameraPosition(Node node);
    }
