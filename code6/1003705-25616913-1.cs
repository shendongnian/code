	List<string> sentenceList = new List<string>(new String[]
		{"Gerald has a nice car", "Rachel has a cute cat"});
    
	List<string> entityList = new List<string>(new String[] 
		{ "Gerald", "car", "Rachel", "cat" });
	List<List<string>> allSentenceEntities = new List<List<string>>();
	foreach (string sentence in sentenceList)
	{
		List<string> currentList = new List<string>();
		foreach(string entity in entityList)
			if (currentSentence.Contains(entity))
				currentList.add(entity);
		if(currentList.Any())
			allSentenceEntities.Add(currentList);
	{
	
