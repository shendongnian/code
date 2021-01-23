        public TreeNode GetNode(string name, TreeNode rootNode)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                if (node.Name.Equals(name)) return node;
                TreeNode next = GetNode(name, node);
                if (next != null) return next;
            }
            return null;
        }
        public TreeNode GetNode(string name)
        {
            TreeNode itemNode = null;
            foreach (TreeNode node in treeViewPermission.Nodes)
            {
                if (node.Name.Equals(name)) return node;
                itemNode = GetNode(name, node);
                if (itemNode != null) break;
            }
            return itemNode;
        }
