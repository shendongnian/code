    public Form1()
    {
       InitializeComponent();
       var parent = new TreeNode("Graphic Requests");
       TreeNodesList.Add(new TreeNode("Art Not Started"));
       TreeNodesList.Add(new TreeNode("Art In Progress"));
       TreeNodesList.Add(new TreeNode("Items To Accept/Modify"));
       TreeNodesList.Add(new TreeNode("Final Art Not Locked"));
       foreach (var node in TreeNodesList)
       {
           parent.Nodes.Add(node);
       }
       treeView1.Nodes.Add(parent);
    }
