    private int GetUsernameIndex(string username)
    {
        //Use a using statement so we don't leave the username.txt file
     	//open after we're done reading from it, using will call Dispose for you
    	using(var sr = new StreamReader(@"C:\temp\username.txt"))
    	{
    		string line;
    		var index = 0;
    		//when sr.ReadLine == null, we've reached the end of the file
    		while((line = sr.ReadLine()) != null)
    		{
    			if(string.Equals(line, username))
    				return index;
    			index++;
    		}
    		
    		//Return -1 if username not found
    		return -1;
    	}
    }
