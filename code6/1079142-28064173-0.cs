    public int WordsCount(string text)
    {
    	if (string.IsNullOrEmpty(text))
    	{
    		return 0;
    	}
    
    	var count = 0;
    	var word = false;
    
    	foreach (char symbol in text)
    	{
    		if (!char.IsLetter(symbol))
    		{
    			word = false;
    			continue;
    		}
    
    		if (word)
    		{
    			continue;
    		}
    
    		count++;
    		word = true;
    	}
    
    	return count;
    }
