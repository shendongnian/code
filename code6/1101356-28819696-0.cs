    List<string> ZeroCombiner(string str)
    {
    	// Get number of zeros.
    	var n = str.Count(c => c == '0');
    	var limit = (int)Math.Pow(2, n);
    
    	// Create strings of '0' and 'o' based on binary numbers from 0 to 2^n.
    	var binaryStrings = new List<string>();
    	for (int i = 0; i < limit; ++i )
    	{
    		binaryStrings.Add(Binary(i, n + 1));
    	}
    
    	// Replace each zero with respect to each binary string.
    	var result = new List<string>();
    	foreach (var binaryString in binaryStrings)
    	{
    		var zeroCounter = 0;
    		var combinedString = string.Empty;
    		for (int i = 0; i < str.Length; ++i )
    		{
    			if (str[i] == '0')
    			{
    				combinedString += binaryString[zeroCounter];
    				++zeroCounter;
    			}
    			else
    				combinedString += str[i];
    		}
    		result.Add(combinedString);
    	}
    
    	return result;
    }
    
    string Binary(int i, int n)
    {
    	string result = string.Empty;
    	while (n != 0)
    	{
    		result = result + (i % 2 == 0 ? '0' : 'o');
    		i = i / 2;
    		--n;
    	}
    	return result;
    }
