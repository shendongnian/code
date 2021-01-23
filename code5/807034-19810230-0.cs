        public static TreeNodeCollection SqlToTreeNodeHierarchy(this SqlDataReader dataReader, TreeNode parent)
        {
            // create a parent TreeNode if we don't have one, so we can anchor the new TreeNodes to it
            // I think this will work better than a list since we might be given a real parent..
            if (parent == null)
            {
                parent = new TreeNode("topNode");
            }
            while (dataReader.Read())
            {
                //at the beginning of each row, reset the parent
                var parentNode = parent;
                
                for (var i = 0; i < dataReader.FieldCount; i++)
                {
                    // Adds a new TreeNode as a child of parentNode if it doesn't already exist
                    // at this level, else it will return the existing TreeNode and save 
                    // it onto parentNode. This way, subsequent TreeNodes will always be a child 
                    // of this one, until a new row begins and the parent TreeNode is reset.
                    parentNode = AddUniqueNode(dataReader[i].ToString(), parentNode);
                }
            }
            return parent.Nodes;
        }
        public static TreeNode AddUniqueNode(string text, TreeNode parentNode)
        {
            // if parentNode is null, create new treeNode and return it
            if (parentNode == null)
            {
                return new TreeNode {Name = text, Text = text};
            }
            // if parentNode is not null, do a find for child nodes at this level containing the key
            // we're after (text and name have the same value) and return the first one it finds
            foreach (var childNode in parentNode.Nodes.Find(text, false))
            {
                return childNode;
            }
            // Node does not yet exist, so just add a new node to the parentNode and return that
            return parentNode.Nodes.Add(text, text);
        }
