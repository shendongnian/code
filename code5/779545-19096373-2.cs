    Dictionary<int, TreeNode> ParentCache = new Dictionary<int, TreeNode>();
    private void CreateNode(int id, int parentID, int rank, string text)
    {
        TreeNodeCollection parentNode = root.Nodes;
        if(parentID != 0)
        {
            TreeNode foundParentNode;
            if (!ParentCache.TryGetValue(parentID, out foundParentNode)
                throw new Exception("Given parentID has not been added to the tree yet - " + parentID.ToString());
            parentNode = foundParentNode.ChildNodes;
        }
        
        TreeNode newNode = new TreeNode(text, id.ToString());
        parentNode.Add(newNode);
        ParentCache.Add(id, newNode);
    }
