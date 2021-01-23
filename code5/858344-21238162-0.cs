    public class NodeMetadata {
        public Vector3 cameraPosition;
    }
    public class Path {
        private Dictionary<Node, NodeMetadata> _nodeMetadataMapping;
        public Node[] nodes;
    }
