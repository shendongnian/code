    Dictionary<int, TreeNode> ParentCache = new Dictionary<int, TreeNode>();
    private void CreateNode(int id, int parentID, int rank, string text)
    {
        TreeNodeCollection parentNode = root.Nodes;
        if(parentID != -1)
            parentNode = ParentCache[parentID].ChildNodes;
        
        TreeNode newNode = new TreeNode(text, id.ToString());
        parentNode.Add(newNode);
        ParentCache.Add(id, newNode);
    }
