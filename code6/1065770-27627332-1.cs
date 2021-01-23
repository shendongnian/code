    public static IEnumerable<T> GetValues<T>()
    {
    	return Enum.GetValues(typeof(T)).Cast<T>();
    }
    
    enum Suit { Spade = 1, Heart, Diamond, Cross };
    
    public Main()
    {
    	var values = GetValues<Suit>();
    	foreach(var d in values)
    	{
    		for(int val = 2; val < 11; ++val)
    		{
			Kaart k = new Kaart(val,d);
    		}
    	}
    }
