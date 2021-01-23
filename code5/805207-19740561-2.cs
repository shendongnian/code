    static public IEnumerable<int> ConvertToInt(this IEnumerable<string> source)
    {
	    int x = 0;
	    var result = source.Where(str => int.TryParse(str, out x))
	                        .Select (str => x);
							
	    return result;		
    }
