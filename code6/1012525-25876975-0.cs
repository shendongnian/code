    public TreeNode NodeByIndex(TreeNode root, int NodeIndex)
    {
      if (root.NodeIndex == NodeIndex)
        return root;
    
      if (root.FirstChild != nil)
      {
        TreeNode c = NodeByIndex(root.FirstChild, NodeIndex);
        if (c != nil)
          return c;
      }
    
      if (root.NextSibling != nil)
      {
        TreeNode c = NodeByIndex(root.NextSibling, NodeIndex);
        if (c != nil)
          return c;
      }
      
      return null;
    }
