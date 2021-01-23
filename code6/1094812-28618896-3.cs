    Dictionary<string, bool> tvCheckStates = null;
    void storeChecks(TreeNode node)
    {
        if (tvCheckStates.Keys.Contains(node.Name))
            throw new Exception("duplicate node name:" + node.Name);
        else tvCheckStates.Add(node.Name, node.Checked);
        foreach (TreeNode n in node.Nodes) storeChecks(n);
    }
    void restoreChecks(TreeNode node)
    {
        if (tvCheckStates.Keys.Contains(node.Name))
            node.Checked = tvCheckStates[node.Name];
        else throw new Exception("node not found:" + node.Name);
        foreach (TreeNode n in node.Nodes) restoreChecks(n);
    }
