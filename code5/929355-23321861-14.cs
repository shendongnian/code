    public class DepthTreeVisitor : ITreeVisitor
    {
        private int _currentDepth = -1;
        public void Visit(TreeNode node)
        {
            _currentDepth++;
            node.Left.Accept(this);
            node.Right.Accept(this);
            _currentDepth--;
        }
        public void Visit(TreeLeaf leaf)
        {
            _currentDepth++;
            if (_currentDepth > Depth)
                Depth = _currentDepth;
            _currentDepth--;
        }
        public int Depth { get; private set; }
    }
