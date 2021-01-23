    var table = result.Tables[0];
    for (int i = 0; i < table.Rows.Count; i++)
    {
         var periodStartDate = Convert.ToDateTime(table.Rows[i]["Date"].ToString()
                                      .Remove(10));
         var periodEndDate   = Convert.ToDateTime(table.Rows[i]["Date"].ToString()
                                      .Remove(0, 12));
    
         // And the rest of the fields...
    
         cList.Add(calc);
    }
