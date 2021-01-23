    public class TreeNode
    {
        public TreeNode Parent { get; private set; }
        public List<TreeNode> ChildNodes { get; set; }
        public TreeNode(TreeNode parent) 
        {
            Parent = parent;
        }
    }
