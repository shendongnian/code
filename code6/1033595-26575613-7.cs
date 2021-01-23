    public class NodeBase : IEqualityComparer, IEnumerable, IEnumerable<NodeBase>
    {
        [XmlIgnore]
        public NodeBase Parent { get; private set; }
        [XmlIgnore]
        public IEnumerable<NodeBase> Children
        {
            get
            {
                return this.children;
            }
        }
        [XmlArray("Children"), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public NodeBase [] ChildList
        {
            get
            {
                return children.ToArray();
            }
            set
            {
                if (!object.ReferenceEquals(value, this.children))
                {
                    children.Clear();
                    foreach (var child in value)
                        AddChild(child);
                }
            }
        }
    }
