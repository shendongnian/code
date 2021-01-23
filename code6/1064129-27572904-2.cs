    void Main()
    {
        // Quick sanity check.
    	
        string str = "111PH1234567X";
    
    	Stopwatch stopwatch = Stopwatch.StartNew();
    	
    	for (int i = 0; i < 1000000; i++)
    	{
    	    if (str.Substring(0, 3).All(char.IsDigit)           //first 3 are digits
    	           && str[3] == 'P'                             //4th is P
    	           && char.IsLetter(str[4])                     //5th is a letter
    	           && str.Substring(5, 7).All(char.IsDigit)     //6-12 are digits 
    	           && char.IsDigit(str[12]) || str[12] == 'X')  //13 is a digit or X
    	   {
    	       ;
    		   //Console.WriteLine("good");
    	   }
    	}
    	
    	Console.WriteLine(stopwatch.Elapsed);
    	
    	stopwatch = Stopwatch.StartNew();
    	
    	Regex regex = new Regex(@"^\d{3}P[A-Z]\d{7}[0-9X]$", RegexOptions.Compiled);
    	for (int j = 0; j < 1000000; j++)
    	{
    	    regex.IsMatch(str);
    	}
    	
    	Console.WriteLine(stopwatch.Elapsed + " (regexp)");
    	
    	// A bit more rigorous sanity check.
    	
    	string[] strs = { "111PH1234567X", "grokfoobarbaz", "really, really, really, really long string that does not match", "345BA7654321Z" };
    
    	Stopwatch stopwatch2 = Stopwatch.StartNew();
    	
    	for (int i = 0; i < strs.Length; i++)
    	{
    		for (int j = 0; j < 1000000; j++)
    		{
    			if (strs[i].Substring(0, 3).All(char.IsDigit)           //first 3 are digits
    				&& strs[i][3] == 'P'                                //4th is P
    				&& char.IsLetter(strs[i][4])                        //5th is a letter
    				&& strs[i].Substring(5, 7).All(char.IsDigit)        //6-12 are digits 
    				&& char.IsDigit(strs[i][12]) || strs[i][12] == 'X') //13 is a digit or X
    			{
    			    ;
    				//Console.WriteLine("good");
    			}
    		}
    	}
    	
    	Console.WriteLine(stopwatch2.Elapsed);
    	
    	stopwatch2 = Stopwatch.StartNew();
    	
    	Regex regex2 = new Regex(@"^\d{3}P[A-Z]\d{7}[0-9X]$", RegexOptions.Compiled);
    	for (int i = 0; i < strs.Length; i++)
    	{
    		for (int j = 0; j < 1000000; j++)
    		{
    			regex2.IsMatch(strs[i]);
    		}
    	}
    	
    	Console.WriteLine(stopwatch2.Elapsed + " (regexp)");
    }
