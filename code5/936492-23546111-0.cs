    public static class NodeExtensions
    {
        static IEnumerable<TreeNode> Descendants(this TreeNode root) {
            var nodes = new Stack<TreeNode>(new[] { root });
            while (nodes.Count > 0) {
                TreeNode node = nodes.Pop();
                yield return node;
                foreach (TreeNode n in node.Nodes) nodes.Push(n);
            }
        }
    }
