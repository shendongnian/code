    void Main()
    {
    	var filePath ="C:\\TEST.DAT";
    	
    	if(!File.Exists(filePath)){ DisplayFileNotFoundError(filePath); }
    	
    	try
    	{	        
    		var lines = GetFileLines(filePath);
    		if(lines == null) { DisplayFileNotFoundError(filePath);}
    		
    		// do work with lines;
    	}
    	catch (Exception ex)
    	{
    		DisplayFileReadException(ex);
    	}
    	
    }
    
    void DisplayErrorMessageToUser(string filePath)
    {
    	Console.WriteLine("The file does not exist");
    }
    
    void DisplayFileReadException(Exception ex){
    	Console.WriteLine(ex.Message);
    }
    
    string[] GetFileLines(string filePath){
    	
    	if(!File.Exists(filePath)){ return null; }
    	
    	string[] lines;
    	try
    	{	        
    		lines = File.ReadLines(filePath);
    		return lines;
    	}
    	catch (FileNotFoundException fnf){
    		Trace.WriteLine(fnf.Message);
    		return null;
    	}
    	catch (Exception ex)
    	{
    		Trace.WriteLine(ex.Message);
    		throw ex;
    	}
    }
