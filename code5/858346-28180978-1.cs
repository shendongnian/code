    public class Path {
        
        // wraps a node and its metadata
        private class NodeData {
            // public members visible only to parent class
            public Node Node;
            public float SomeMetadata;
        }
        
        // private array...
        private NodeData[] nodeData;
        
        // ...public method
        public Node GetNode(int index) {
            return nodeData[index].Node;
        }
    }
