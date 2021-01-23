        public void SetIconsTreeNodes(IEnumerable<TreeNode> treeNodeCollection)
        {
            foreach (TreeNode node in treeNodeCollection)
            {
                // Set imageindex of node here with your own conditions
                TreeNode[] nodes = new TreeNode[node.Nodes.Count];
                node.Nodes.CopyTo(nodes, 0);
                SetIconsTreeNodes(nodes);
            }
        }
