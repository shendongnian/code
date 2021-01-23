    private bool SomeMethod(String path, String id)
    {
    	string [] column ;
    
    	foreach (string line in File.ReadLines(Path))
    	{  
    		column = line.Split(',');
            //check that there are at least 5 columns before comparing it with ID
    		if ((column.Length >= 5) && (id == column[4]))
    		{
    			return false;
    		}
    	}
    }
