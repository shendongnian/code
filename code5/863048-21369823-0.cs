    dataGrid_FileContents.Rows.Clear();
    
    char delimiter = '=';
    
    using(StreamReader fileReader = new StreamReader(fileLocation))
    {
    	string[] data = new string[2];
    	
    	while(true)
    	{
    		string row = fileReader.ReadLine();
    		if(row == null)
    			break;
    		
    		string[] items = row.Split(delimiter);
    		int data_index = 0;
    		foreach(string item in items)
    		{
    			if(data_index >= data.Length)
    			{
    				//TODO: log warning
    				break;
    			}
    			
    			if(!string.IsNullOrWhiteSpace(item))
    			{
    				data[data_index++] = item;
    			}
    			
    		}
    		
    		if(data_index < data.Length)
    		{
    			//TODO: log error, only 1 item in row
    			continue;
    		}
    		
    		
    		dataGrid_FileContents.Rows.Add(data[0], data[1]);
    		
    	}
    }
