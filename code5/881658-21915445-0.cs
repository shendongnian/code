    private void PopulateTreeView()
    {
        treeView1.Nodes.Add(AddSubNode(0, new TreeNode("Root")));
    }
    private TreeNode AddSubNode(int level, TreeNode hierarchy)
    {
        if (level == StructureArray.Length)
        {
            return hierarchy;
        }
        foreach (string s in StructureData[StructureArray[i]])
        {
            tn.Nodes.Add(AddSubNode(level + 1, new TreeNode(s)));
        }
        return tn;
    }
