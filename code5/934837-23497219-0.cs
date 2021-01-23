    public interface IHalfedge
    {
    }
    public interface IEdge
    {
    }
    public interface IVertex
    {
    }
    public interface IFace
    {
    }
    public class Graph
    {
        private class Halfedge : IHalfedge
        { /* ... */
        }
        private class Edge : IEdge
        { /* ... */
        }
        private class Vertex : IVertex
        { /* ... */
        }
        private class Face : IFace
        {/* ... */
        }
        // Cannot return a Face, since it is not public.
        public IFace AddFace(/* params about the vertexes of the face to create */)
        {
            /* Algorithm to create halfegdes, edges, vertices and a face */
        }
    }
