    protected void tv_WLG_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e) {
      if (e.Node.Checked) {
        var stack = new Stack<TreeNode>();
        stack.Push(e.Node);
        while (stack.Count > 0) {
          var node = stack.Pop();
          node.Checked = true;
          foreach (TreeNode childNode in node.ChildNodes) {
            stack.Push(childNode);
          }
        }
      }
    }
