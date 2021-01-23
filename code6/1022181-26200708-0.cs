    void Main()
    {	
    	var line = @"/hello/1 /a/sdhdkd asjs /hello/2 ajhsd asjskjd skj 
                   /hello/s sajdk /hello/3 assdsfd hello/4";
    	var searchString = "/hello/";
    	var index = line.IndexOf(searchString);
    	
    	var values = new List<string>();
    	
    	while(index != -1)
    	{
    		var nextCharacterIndex = index + searchString.Length;
    	
    		// check if the second character exists
    		// and if it's a number.
    		if(nextCharacterIndex < line.Length)
    		{
    			var nextCharacter = line[nextCharacterIndex];
    			if(Char.IsDigit(nextCharacter))
    				values.Add(searchString + nextCharacter);
    		}
         
            // skip our previously found hello/<somenumber>
    		index = line.IndexOf(searchString, nextCharacterIndex);
    	}	
    	
    	Console.WriteLine(values);
    }
