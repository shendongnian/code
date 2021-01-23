    public void UpdateScan(string input, string ip)
    {
        lock (outputTree)
        {
            outputTree.BeginUpdate();
            if (! outputTree.Nodes.ContainsKey(input))
            {
                TreeNode treeNode = new TreeNode(input);
                treeNode.Name = input;
                //Add our parent node
                outputTree.Nodes.Add(treeNode);
                //Add our child node
                treeNode.Nodes.Add(ip);
            }
            else
            {
                TreeNode[] found = outputTree.Nodes.Find(input, true);
                TreeNode newChild = new TreeNode(ip);
                //Add only child node
                found[0].Nodes.Add(newChild);
            }
            outputTree.EndUpdate();
        }
    }
