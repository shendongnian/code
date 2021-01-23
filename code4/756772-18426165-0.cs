        treeView.BeginUpdate();
        //Loop through all the nodes of tree
        foreach (TreeNode node in myMember.Nodes)
        {
            //If node has child nodes
            if (node.FirstNode != null)
            {
                if (node.Checked == true)
                {
                    //Check all the child nodes.
                    foreach (TreeNode childNode in node.Nodes)
                    {
                        childNode.Checked = true;
                    }
                }
            }
        }
        treeView.EndUpdate();
