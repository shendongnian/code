    private TreeNode nodeFromPath(String path)//Converts a treenode path into a treenode
    {
        TreeNode tn = new TreeNode();
        char[] delimiters = {'\\'};
        string[] roots = path.Split(delimiters);
        List<int> nodeIndeces = new List<int>();
        for(int j = 0; j < roots.Length ;j++)
        {
            nodeIndeces.Add(selectedNode.Index);
            selectedNode = selectedNode.Parent;
        }
        nodeIndeces.Reverse();
        tn = treeView1.Nodes[0];
        for (int i = 1; roots.Length > i; i++)
        {
            tn = tn.Nodes[nodeIndeces[i]];
        }
        return tn;
    }//end nodeFromPath
