    private List<TreeNode> AllCheckedNodes = new List<TreeNode>();
    
    private void GetAllCheckedNodes()
    {
        for (int i = 0; i < TreeView1.CheckedNodes.Count; i++)
        {
            AllCheckedNodes.Add(TreeView1.CheckedNodes[i]);
        }
    }
