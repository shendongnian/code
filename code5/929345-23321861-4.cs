    public class SumTreeVisitor : ITreeVisitor
    {
        public override void Visit(TreeNode node)
        {
            node.Left.Accept(this); // left and right should be properties
            mode.Right.Accept(this);
        }
    
        public override void Visit(TreeLeaf leaf)
        {
            Sum += leaf.Value;
        }
    
        public int Sum { get; private set; }
    }
