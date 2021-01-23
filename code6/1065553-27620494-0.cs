    private TreeNode GetNodeByStringPath(TreeNode root, string path)
        {
            string[] pathArr = path.Split('/');
            if (pathArr.First() != root.Name)
                return null;
            TreeNode currentNode = root;
            for (int i = 1; i < pathArr.Length &&currentNode!=null; i++)
            {
                int index = currentNode.Nodes.IndexOfKey(pathArr[i]);
                currentNode = currentNode.Nodes[index];
            }
            return currentNode;
        }
