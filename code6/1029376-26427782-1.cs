    foreach (DataRow row in myDataTable.Rows)
    {
      str_desc = row.Field<string>(1);
      str_key = row.Field<string>(2);
    
      TreeNode node = new TreeNode(str_key + "-" + str_desc);
    			
      int lvl = 1;
    
      addToLvl(lvl, trv_waregroup, trv_waregroup.Nodes[trv_waregroup.GetNodeCount(false) - 1], str_key.Length, node);
    
    }
    			
    public void addToLvl(int actualLvl, TreeView tv, TreeNode last, int lvlToReach, TreeNode nodeToAdd)
    {
      if (actualLvl == lvlToReach)
        last.Nodes.Add(node);
      else
        addToLvl(actualLvl++, tv, last.LastNode, lvlToreach, nodeToAdd);
    }
