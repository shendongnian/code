    public static IEnumerable<TreeNode> Descendants(this TreeNodeCollection c)
    {
        foreach (var node in c.OfType<TreeNode>())
        {
            yield return node;
 
            foreach (var child in node.Nodes.Descendants())
            {
                yield return child;
            }
        }
    }
