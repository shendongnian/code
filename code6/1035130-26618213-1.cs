	public static Dictionary<string,int> groupCount(string str, int groupSize) 
	{
		string[] tokens = str.Split(new char[] { ' ' });
		
		var dict = new Dictionary<string,int>();
		for ( int i = 0; i < tokens.Length - (groupSize-1); i++ ) 
		{
			string key = "";
			for ( int j = 0; j < groupSize; j++ ) 
			{
				key += tokens[i+j] + " ";
			}
			key = key.Substring(0, key.Length-1);
			
			if ( dict.ContainsKey(key) ) {
				dict[key]++;
			} else {
				dict[key] = 1;
			}
		}
		
		return dict;
	}
