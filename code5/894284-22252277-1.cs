    public static class TreeViewEx {
      public static List<TreeNode> GetParentNodes(this TreeView treeView) {
        List<TreeNode> results = new List<TreeNode>();
        foreach (TreeNode node in treeView.Nodes) {
          results.AddRange(GetNodes(node));
        }
        return results;
      }
      private static List<TreeNode> GetNodes(TreeNode parentNode) {
        List<TreeNode> results = new List<TreeNode>();
        if (parentNode.Nodes.Count > 0) {
          results.Add(parentNode);
          foreach (TreeNode node in parentNode.Nodes) {
            results.AddRange(GetNodes(node));
          }
        }
        return results;
      }
    }
