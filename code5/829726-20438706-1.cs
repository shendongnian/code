    void Main()
    {
    	string[] words = new string[] { "banana", "banana tree" , "banana peel"};
    	
    	string textToCompare = "word banana tree more words";
    
    	List<string> result = new List<string>();
    	
    	for (int i = 0; i < words.Length; i++)
    	{
    		if (textToCompare.Contains(words[i]))
    		{
    			result.Add(words[i]);
    		}
    	}
        var silly_longest = (from r in result orderby r.Length descending select r).Take(1);
    }
