	foreach (string s1 in list1)
	{
		Dictionary<string,List<string>>() innerDictionary = new Dictionary<string,List<string>>();
		foreach (string s2 in list2)
		{
			List<string>() list4 = new List<string>();
			foreach(string s3 in list3)
			{
				list4.Add(s3);
			}
			innerDictionary.Add(s2, list4);
		}
		mainDictionary.Add(s1, innerDictionary);
	}
