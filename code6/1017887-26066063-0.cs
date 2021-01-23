    foreach (var character in stringToCount)
    {
    	if (char.IsLetterOrDigit(character))
    	{
    		alphaNumericCount++;
    		
    		if (char.IsLower(character))
    			lowercaseCount++;
    
    		else if (char.IsUpper(character))
    			uppercaseCount++;
    	}
    }
