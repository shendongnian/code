    foreach (var item in ProductCategory)
    {
        TreeNode treeCustomItem = new TreeNode(item.CatName);
        List<dataObject> lst = objFreecusatomization.GetAllCustomItems(CategoryType.Dressing, item.CategoryID);
        List<TreeNode> sumItemList = new List<TreeNode>();
    
        foreach (var subItem in lst)
        {
            sumItemList.Add(new TreeNode { ... });
        }
        treeCustomItem.Nodes.AddRange(sumItemList.ToArray());
    }
