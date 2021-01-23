    Private Sub populateNodes(dt as DataTable)
    {
      populateParentNodes(dt);
    
      foreach (DataRow dr in dt.Rows)
      {
         if(dr["Name"].ToString().Trim().Lenght() > 1)
         {
          Tree.Nodes.FindNodeByName(dr["Name"].ToString().SubString(1,1)).Add(dr["Name"].ToString());
         }
      }
    }
    Private Function populateParentNodes(DataTable dt)
    {
      foreach (DataRow dr in dt.Rows)
      {
         if(dr["Name"].ToString().Trim().Lenght() == 1)
         {
            Tree.Nodes.Add(dr["Name"].ToString());
         }
      }
    }
