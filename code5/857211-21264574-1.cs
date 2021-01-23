    foreach (string k in context.Request.QueryString)
    	{ 		
    		if (k.StartsWith("children")){
            foreach (string v in context.Request.QueryString.GetValues(k)){
               ListDictionary updateParamss = new ListDictionary();
    			updateParamss.Add("row_id",  v);
    
    			   string Sql = @"insert into dug  select :row_id from dual";
    			     dbi.ExecuteNonQuerySql(Sql, updateParamss);
    				 }
    			}
    			
    
    	}
