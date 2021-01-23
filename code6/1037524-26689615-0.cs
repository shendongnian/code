    private TreeNode SearchNode(string nodetext, object obj)
        {
    
            if(obj.GetType() Is TreeView)
            {
                  t = (TreeView)obj;
                  foreach (TreeView tv in obj.Nodes)
                  {
                     if (tv.Text == nodetext)
                     {
                         return nd;
                     }
                  }
     
            }
            else
            {
                  n = (TreeNode)obj;
                  foreach (TreeNode nd in obj.Nodes)
                  {
                      if (nd.Text == nodetext)
                      {
                         return nd;
                      }
                  }
     
            }
            return null;
        }
