	List<string> sentenceList = new List<string>(new String[]
	{"Gerald has a nice car", "Rachel has a cute cat"});
	
			List<string> entityList = new List<string>(new String[] 
	{ "Gerald", "car", "Rachel", "cat" });
    foreach (string sentence in sentenceList)
    {
		var words = sentence.Split(" ".ToCharArray());
		var valid_words = words.Where (w => entityList.Any (en_li => en_li.Equals(w)));
		valid_words.Dump("for " + sentence);
	}
