    HashSet<string> primaryKeyChecker = new HashSet<string>();
    
    foreach (var row in rows)
    {
    
    	StringBuilder primaryKey = new StringBuilder();
    	//Get rowCount;
    
    	foreach (var column in columns)
    	{
    		(if column is a composite of a primaryKey)
    		{
    			get column value;
    			append it to stringBuilder to form the primaryKey
    		}	
    	}
    
                                var addOutcome = primaryKeyChecker.Add(primaryKey.ToString());
    
                                if (!addOutcome)
                                {
                                    //Report a duplicate record and give the rowNumber where this occured.
                                }
    
    
    }
