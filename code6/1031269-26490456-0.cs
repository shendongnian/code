    private TreeNode GetSelectedNodes(TreeNode treeNode)
        {
            
            foreach (TreeNode node in treeNode.Nodes)
            {
                if (node.Text=="Child1")
                {
                   
                      return node;
                }
                else
                if (node.Nodes.Count > 0)
                {
                    var result = this.GetSelectedNodes(node);
                   if(result != null)
                       return result;
                }
            }
            return null;
        }
