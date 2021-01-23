         private void Caller()
        {
            TraverseTreeNode(treeView1.Nodes);
        }
        private void TraverseTreeNode(TreeNodeCollection nodes)
        {
            int index = 1;
            foreach (TreeNode node in nodes)
            {
                node.Text = (node.Parent != null ? node.Parent.Text : string.Empty) + index++;
                TraverseTreeNode(node.Nodes);
            }
        }
