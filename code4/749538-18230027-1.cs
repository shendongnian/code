    List<TreeNode> sumItemList = new List<TreeNode>();
    
    foreach (var subItem in lst)
    {
        sumItemList.Add(new TreeNode { ... });
    }
    treeCustomItem.Nodes.AddRange(sumItemList.ToArray());
