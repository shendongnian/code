    private void SortBranch(TreeNode parentNode) {
      TreeNode[] nodes;
      if (parentNode == null) {
        nodes = new TreeNode[treeView1.Nodes.Count];
        treeView1.Nodes.CopyTo(nodes, 0);
      } else {
        nodes = new TreeNode[parentNode.Nodes.Count];
        parentNode.Nodes.CopyTo(nodes, 0);
      }
      Array.Sort(nodes, new TreeSorter());
      treeView1.BeginUpdate();
      if (parentNode == null) {
        treeView1.Nodes.Clear();
        treeView1.Nodes.AddRange(nodes);
      } else {
        parentNode.Nodes.Clear();
        parentNode.Nodes.AddRange(nodes);
      }
      treeView1.EndUpdate();
    }
