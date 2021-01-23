    public class Path {
        
        // private, wraps a node and metadata
        private class NodeData {
            public Node Node; // members visible only to parent class
            public Vector3 CameraPosition;
            public float TimeStamp;
        }
        
        // private member...
        private NodeData[] nodeData;
        
        // ...public method
        public Node GetNode(int index) {
            return nodeData[index].Node;
        }
    }
