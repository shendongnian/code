    private void ChangeNodesSelection(TreeNodeCollection node,bool doCheck)
        {
            foreach (TreeNode n in node)
            {
                n.Checked = doCheck;
                if (n.Nodes.Count > 0)
                {
                    ChangeNodesSelection(n.Nodes,doCheck);
                }
            }
        }
