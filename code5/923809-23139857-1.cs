    public static IEnumerable<int> ParseIntegers(string val, char seperator = ',')
    {
    	foreach (string str in val.Split(new [] { seperator }, StringSplitOptions.RemoveEmptyEntries))
    	{
    		int res;
    		if (int.TryParse(str, out res))
    		{
    			yield return res;
    		}
    	}
    }
