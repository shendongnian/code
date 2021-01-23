    public void GetCheckedNodes(TreeNodes nodes)
    {
        foreach(System.Windows.Forms.TreeNode aNode in nodes)
        {
             if (aNode.Checked != true)
                continue;
    
             Console.WriteLine(aNode.Text);
    
             if(aNode.Nodes.Count != 0)
                GetCheckedNodes(aNode);
        }
    } 
