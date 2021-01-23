    string s = "aa bb cc dd ee ff gg hh ii kk";
	//
	// Split string on spaces.
	// ... This will separate all the words.
	//
	string[] words = s.Split(' ');
	foreach (string word in words)
	{
	    Console.WriteLine(word);
	}
