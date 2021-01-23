    public class CustomTreeNode : TreeNode
    {
        public IEnumerable<TreeNode> Descendants()
        {
            var nodes = new Stack<TreeNode>(new[] { this });
            // rest
        }
    }
