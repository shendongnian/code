    public void GetCheckedNodes(TreeNodeCollection nodes)
    {
        foreach(System.Windows.Forms.TreeNode aNode in nodes)
        {
             //edit
             if(!aNode.Checked)
                 continue;
             
             Console.WriteLine(aNode.Text);
    
             if(aNode.Nodes.Count != 0)
                 GetCheckedNodes(aNode.Nodes);
        }
    } 
