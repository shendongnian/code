    static TreeNode Clone(TreeNode root)
    {
        var currentOriginal = root;
        var currentCloned = Copy(root, null);
        var clonedRoot = currentCloned;
        while (currentOriginal != null)
        {
            if (currentCloned.Children.Count == currentOriginal.Children.Count)
            {
                currentOriginal = currentOriginal.Parent;
                currentCloned = currentCloned.Parent;
            }
            else
            {
                var targetChild = currentOriginal.Children[currentCloned.Children.Count];
                currentOriginal = targetChild;
                currentCloned = Copy(currentOriginal, currentCloned);
            }
        }
        return clonedRoot;
    }
    static TreeNode Copy(TreeNode source, TreeNode parent) { ... }
