    public interface INode
    {
        int Id { get; set; }
        INode Parent { get; }
        ReadOnlyCollection<INode> Children { get; }
        void SetParent(INode node);
        void AddChild(INode node);
    }
    public class Node : INode
    {
        private INode _parent;
        private IList<INode> _children;
  
        public Node()
        {
            _children = new List<INode>();    
        }
        public int Id { get; set; }
        public INode Parent
        {
            get { return _parent; }
        }
        public ReadOnlyCollection<INode> Children
        {
            get
            {
                return new ReadOnlyCollection<INode>
                           (_children.OrderBy(c => c.Id).ToList());
            }
        }
        public virtual void AddNode(INode node)
        {
            _children.Add(node);
            node.SetParent(this);
        }
        public virtual void SetParent(INode node)
        {
            _parent = node;
        }
    }
