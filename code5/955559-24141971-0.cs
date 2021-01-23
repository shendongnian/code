    if (File.Exists(filePath)) 
    {
    	string status;
    	using(var streamReader = new StreamReader(filePath))
    	{
    		status = streamReader.ReadLine();
    	}
    
    	if (status != "SUCCEEDED")
    	{
    		File.Delete(filePath);
    		createDb();
    	}
    }
