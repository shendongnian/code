    public static class RandomExtensions
    {
    	public static int Next(this Random random, 
    		int minInclusive, 
    		int maxExclusive, 
    		IList<int> values)
    	{
    		
    		// this will crash if values contains
    		// duplicate values.
    		var dic = values.ToDictionary(val => val);
    		
    		// this can go into recursion,
    		// think about this a bit.
    		for(;;){
    			var randomNumber= random.Next(minInclusive, maxExclusive);
    			if(!dic.ContainsKey(randomNumber))
    				return randomNumber;
    		}
    	}
    }
