        void SelectNodeOnTreeView(string EmpID, TreeNodeCollection NodeCollection) 
        {
            if (NodeCollection.Count > 0)
            {
                foreach (TreeNode node in NodeCollection)
                {
                    if (node.Text == EmpID)
                    {
                        treeView1.SelectedNode = node;
                        break;
                    }
                    SelectNodeOnTreeView(EmpID, node.Nodes);
                }
            }
        }
