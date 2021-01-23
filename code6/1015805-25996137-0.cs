    public void DoTheNeedfull(ItemLimit[] itemLimits, DataSet dataSet)
	{
		var itemLimitDictionary = itemLimits.ToDictionary(i => MakeKey(i.One, i.Two), i => i);
		
		for(var i = 0; i < dataSet.Count; i++)
		{
			var strUnEditedHomingAccountNo = BlackMagicMethod(dataSet[i]);
			var key = MakeKey(dataSet[i].User_UserCode, strUnEditedHomingAccountNo);
			
			if(itemLimitDictionary.ContainsKey(key))
			{
				// do your thing
			}
			else
			{
				// maybe this is an error
			}
		}
	}
	private string MakeKey(string keyPartOne, string keyPartTwo)
	{
		return keyPartOne.ToUpperInvariant() + keyPartTwo.ToUpperInvariant();
	}
