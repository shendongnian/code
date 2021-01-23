    public delegate bool TryParseDelegate<T>(string str, out T value);
    
    public static Tuple<Func<string, bool>, Type> ParsesAs<T>(TryParseDelegate<T> d)
    {
    	Func<string, bool> f = s =>
    	{
    		T val;
    		return d(s, out val);
    	};
    
    	return Tuple.Create(f, typeof(T));
    }
    
    public static Type FindBestType(List<string> input)
    {
    	var parsers = new List<Tuple<Func<string, bool>, Type>>
    	{
    		ParsesAs<int>(int.TryParse),
    		ParsesAs<double>(double.TryParse)
    	};
    
    	int i = 0;
    	foreach (string str in input)
    	{
    		while (i < parsers.Count && !parsers[i].Item1(str))
    		{
    			i++;
    		}
    		if (i == parsers.Count) break;
    	}
    
    	return i == parsers.Count ? typeof(string) : parsers[i].Item2;
    }
