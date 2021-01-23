        private void tvwTest_AfterCheck(object sender, TreeViewEventArgs e)
        {
            checkNodes(e.Node);
        }
        private void checkNodes(TreeNode root)
        {
            foreach (TreeNode node in root.Nodes)
            {
                node.Checked = root.Checked;
                checkNodes(node);
            }
        }
