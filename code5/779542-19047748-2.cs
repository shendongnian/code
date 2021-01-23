        private List<TreeNode> CreateNodes(List<TempTreeNode> nodes)
        {
            var rootNodes = new List<TreeNode>();
            foreach (var node in nodes)
            {
                if (node.ParentID == -1)
                {
                    TreeNode _Node = new TreeNode(node.Lang, node.MenuID.ToString());
                    rootNodes.Add(_Node);
                }
                [...] do whatever...
            }
            return rootNodes;
        }
