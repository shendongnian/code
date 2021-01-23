    public static bool IsLeaf (this System.Windows.Forms.TreeNode tn)
    {
      System.Windows.Forms.TreeNodeCollection children = tn.Nodes;
      return (children == null || children.Count == 0);
    }
