    public class NodeBase 
    {
        public NodeBase Parent { get; private set; }
        public IEnumerable<NodeBase> Children
        {
            get
            {
                return this.children;
            }
        }
    }
