    private void AddNode(FileInfo F)
    {
        // Create the node labels.
        string y = String.Format("{0:yyyy}", F.LastWriteTime);
        string ym = String.Format("{0:yyyy-MM}", F.LastWriteTime);
        string ymd = String.Format("{0:yyyy-MM-dd}", F.LastWriteTime);
        TreeNode[] tnY = null;
        TreeNode[] tnYM = null;
        TreeNode[] tnYMD = null;
        // Find existing tree nodes for the file we are working on.
        tnY = treeView1.Nodes.Find(y, false);
        if (tnY.Length == 1)
        {
            tnYM = tnY[0].Nodes.Find(ym, false);
            if (tnYM.Length == 1)
            {
                tnYMD = tnYM[0].Nodes.Find(ymd, false);
            }
        }
        // Create the missing nodes.
        if (tnY.Length == 0)
        {
            tnY = new TreeNode[1];
            tnY[0] = treeView1.Nodes.Add(y);
        }
        if (tnYM == null || tnYM.Length == 0)
        {
            tnYM = new TreeNode[1];
            tnYM[0] = tnY[0].Nodes.Add(ym);
        }
        if (tnYMD == null || tnYMD.Length == 0)
        {
            tnYMD = new TreeNode[1];
            tnYMD[0] = tnYM[0].Nodes.Add(ymd);
        }
        // And finally, add the node with the file name.
        tnYMD[0].Nodes.Add(F.Name);
    }
