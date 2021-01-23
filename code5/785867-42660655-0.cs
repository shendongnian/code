            public TreeNode GetNode(object tag, TreeNode rootNode)
            {
                foreach (TreeNode node in rootNode.Nodes)
                {
                    if (node.Tag.Equals(tag)) return node;
                    
                    //recursion
                    var next = GetNode(tag, node);
                    if (next != null) return next;
                }
                return null;
            }
    
            public TreeNode GetNode(object tag)
            {
                TreeNode itemNode = null;
                foreach (TreeNode node in _sourceTreeView.Nodes)
                {
                    if (node.Tag.Equals(tag)) return node;
                     
                    itemNode = GetNode(tag, node);
                    if (itemNode != null) break;
                }
                return itemNode;
            }
