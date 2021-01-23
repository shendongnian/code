    var digitCount = new Dictionary<int, int>();
    int lastDigit = 0;
    
    foreach (int i in ip)
    {
    	//don't count 0 digits
    	if(i != 0)
    	{
    		//if current digit already in dictionary
    		if (digitCount.ContainsKey(i))
    		{
    			//if continous, increment counter for corresponding digit
    			if (lastDigit == i)
    				digitCount[i] = ++digitCount[i];
    			//else reset counter to 1
    			else
    			{
    				digitCount[i] = 1;
    			}
    		}
    		//add current digit to dictionary and set counter value to 1
    		else
    		{
    			digitCount.Add(i, 1);
    		}
    	}
    	
    	lastDigit = i;
    }
    
    //get dictionay item having largest value
    Console.WriteLine(digitCount.OrderByDescending(o => o.Value).First());
