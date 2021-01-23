    List<string> Flop = new List<string>();
    
    	for (int x = 0; x <= Dataset9.Tables[0].Rows.Count - 1; x++)
    	  {
    		Flop.Add(Dataset9.Tables[0].Rows[x]["Id"]);
    	  }
     strAllRoleNames = string.Join(",", Flop.ToArray());
