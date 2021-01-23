    public class NodeBase : IEqualityComparer, IEnumerable, IEnumerable<NodeBase>
    {
        [XmlIgnore]
        public NodeBase Parent { get; private set; }
        public IEnumerable<NodeBase> Children
        {
            get
            {
                return this.children;
            }
        }
    }
