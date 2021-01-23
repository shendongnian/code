    [ProtoContract]
    public class Graph
    {
        // All of the devices on the graph
        [ProtoMember(1)]
        public readonly Dictionary<int, Vertex> Vertex;
        // All of the links in the graph
        [ProtoMember(2)]
        public readonly List<Edge> Links;
        
        [OnDeserialized]
        public void OnDeserialized() {
            // Add references to all of the links
            foreach (Edge l in Links) {
                l.Vertices[0] = this.Vertex[l.VertexIds[0]];
                l.Vertices[1] = this.Vertex[l.VertexIds[1]];
            }
        }
    }
    
    // A vertex of the graph
    [ProtoContract]
    public class Vertex
    {
        [ProtoMember(1)]
        public readonly int Id;
        
        /*
    we index the edges by the ID of the other device.
    It makes it easy to find specific edges and makes it trivial to only track 1 copy of an edge
        */
        [ProtoMember(2)]
        public readonly Dictionary<int, Edge> Edges;
    }
    
    // An edge
    [ProtoContract(AsReferenceDefault = true)]
    public class Edge
    {
        public readonly Vertex[] Vertices;
        
        [ProtoMember(1)]
        public readonly int[] VertexIds;
        
        [ProtoMember(2)]
        public readonly Direction Direction;
        public Edge() {
            this.Vertices = new Vertex[2];
            this.Direction = Direction.None;
            /*
    important to note that we don't set the VertexIds array in this constructor.
    protobuf-net will create it for us, and if we create it here, we'll end up with a 4 length array.
            */
        }
    }
    
    /*
    denotes to which index in a edge's devices array the direction the edge goes.
    [Flags] so we can do checks easier:
    Edge.Direction == Direction.Both implies Edge.Direction & Direction.ZeroToOne != 0
    */
    [Flags]
    public enum Direction {
        None = 0,
        ZeroToOne = 1,
        OneToZero = 2,
        Both = 3
    }
