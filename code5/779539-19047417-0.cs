    TreeView tv = new TreeView();
    private void populateNode()
    {
      
       for(int i=0;i<5;i++)
       {
          var parent = new TreeNode(i,string.Format("Node{0}",i));
          tv.Nodes.Add(parent);
          for(int j=0;j<=3;j++)
          {
            var child = new TreeNode(j,string.Format("childNode{0}",j)
            parent.ChildNodes.Add(child);
            for(int k=0;k<=3;k++)
            {
              var grandchild = new TreeNode(k,string.Format("grandchildNode{0}",k)
              child.ChildNodes.Add(grandchild);
            
            }
          }
       }
       
    }
