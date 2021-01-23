    //Use this to get all the Checked child nodes under a Parent node
    private List<TreeNode> GetCheckedNodes(TreeNode node){
      List<TreeNode> nodes = new List<TreeNode>();
      if(node.Checked) nodes.Add(node);
      foreach(TreeNode n in node.Nodes)
        nodes.AddRange(GetCheckedNodes(n));
      return nodes;
    }
    
     
     foreach (TreeNode node in taskslctor_treeview.Nodes) {               
        foreach(TreeNode childNode in GetCheckedNodes(node)){
            check.Add(childNode.Text);
            MessageBox.Show(check.ToString());
        }
     }
     if (check.Count == 0){
        MessageBox.Show("Atleast one task needs to be selected!!", "Error");
     }
