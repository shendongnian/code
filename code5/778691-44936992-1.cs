    public class TreeNode
    {
        public ImmutableStack<TreeNode> NodeStack { get; private set; }
        public ImmutableStack<TreeNode> ParentStack { get { return NodeStack.IsEmpty ? ImmutableStack<TreeNode>.Empty : NodeStack.Pop(); } }
        public TreeNode Parent { get { return ParentStack.IsEmpty ? null : ParentStack.Peek(); } }
        public ImmutableArray<TreeNode> ChildNodes { get; set; }
        public TreeNode(TreeNode parent)
        {
            if (parent == null)
                NodeStack = ImmutableStack<TreeNode>.Empty;
            else
                NodeStack = parent.NodeStack.Push(this);
        }
    }
