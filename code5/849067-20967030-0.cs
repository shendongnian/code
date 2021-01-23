    public Dictionary<string, int> Rank(string[] orderedKeys, int[] orderedValues)
	{
	    Dictionary<string, int> rankedDictionary = new Dictionary<string, int>();
	    for (int i = 0; i < orderedKeys.Length; i++)
	    {
	        rankedDictionary.Add(orderedKeys[i], orderedValues[i]);
	    }
	    return rankedDictionary;
    }
	public void CallRank()
	{
        string[] orderedKeys = new[] { "dogs", "cats", "fish", "birds" };
        int[] orderedValues = new[] { 10, 12, 19, 20 };
	    Dictionary<string,int> rankedResults =  Rank(orderedKeys, orderedValues);
	    int catsValue = rankedResults["cats"];
	}
