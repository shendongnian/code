    public void ShowTree(TreeView tree)
    {
        // Must assign null first ..
        Action<TreeNode> showNode = null;
        showNode = (node) => {
          MessageBox.Show(node.ToString());
          foreach (TreeNode child in node.Nodes)
          {
              // .. so this won't be an "unassigned local variable" error
              showNode(child);
          }
        };
        foreach (TreeNode node in tree.Nodes)
        {
            showNode(node);
        }
    }
