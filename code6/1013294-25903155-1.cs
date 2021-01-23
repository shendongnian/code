     public List<CustomObject> ExecuteCustomQuery(List<int> items)
     {
    		var ids = string.Join(",", items.Select(i => i.ToString()).ToArray());
           string query = "SELECT Column1, Column1 FROM TABLE1 where id in (" + ids + ")";
    	   return dbContext.Database.SqlQuery<CustomObject>(query).ToList();
    
    
    }
