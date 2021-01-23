    private TreeNode GetSelectedNodes(TreeNode treeNode)
    {
        TreeNode result=new TreeNode();
        foreach (TreeNode node in treeNode.Nodes)
        {
            if (node.Text=="Child1")
            {
                result=node;
                return result;
            }
            else if (node.Nodes.Count > 0)
            {
                return this.GetSelectedNodes(node);
            }
        }
    }
