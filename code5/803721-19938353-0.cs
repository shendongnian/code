    protected void makemainNodes(TreeNodeCollection treec, System.IO.DirectoryInfo directory)
    {
        foreach (System.IO.DirectoryInfo g in directory.GetDirectories())
        {               
            TreeNode child = new TreeNode(g.Name);                
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(g.FullName);
            child.ImageUrl = "~/Images/folder.png";            
            makesubNodes(child, dir);
            treec.Add(child);
        } 
    }
    protected void makesubNodes(TreeNode treec, System.IO.DirectoryInfo directory)
    {
        foreach (System.IO.DirectoryInfo g in directory.GetDirectories())
        {              
            TreeNode child = new TreeNode(g.Name);
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(g.FullName);
            child.ImageUrl = "~/Images/folder.png";
            makesubNodes(child, dir);
            treec.ChildNodes.Add(child);
        } 
    }
