    public class TreeNode : ITreeNode
    {
        public ITreeNode Left { get; private set; }
        public ITreeNode Right { get; private set; }
        public TreeNode(ITreeNode left, ITreeNode right)
        {
            Left = left;
            Right = right;
        }
        public void Accept(ITreeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
