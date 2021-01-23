	//emulate the repeat step. http://stackoverflow.com/q/17865166/1180926
	List<List<char>> zeroOneRepeated = Enumerable.Range(0, k)
		.Select(i => '01'.ToList())
		.ToList(); 
	//get the product and turn into strings
	objectsOfInterest = CrossProductFunctions.CrossProduct(zeroOneRepeated)
		.Select(item => new string(item.ToArray()));
	//create the dictionary. http://stackoverflow.com/a/938104/1180926
	myDict = objectsOfInterest.GroupBy(str => str.Substring(0, str.Length - 1))
		.ToDictionary(
			grp => grp.Key, 
			grp => gdc.Select(str => str.Substring(1)).ToList()
		);
