    foreach (DataRow data in result.Tables[0].Rows)
    {
         var periodStartDate = Convert.ToDateTime(data["Date"].ToString().Remove(10));
         //You can simplify rest like this with `data`
    }
    for (int i = 0; i < result.Tables[0].Rows.Count; i++)
    {    
        DataRow data = result.Tables[0].Rows[i];
        var periodStartDate = Convert.ToDateTime(data["Date"].ToString().Remove(10)); 
        //And so on   
    }
