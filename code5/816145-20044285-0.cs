    var replacements = new Dictionary<char, string>();
    replacements.Add('a', "b");
    replacements.Add('b', "a");
    var inputString = "abc";
    var etalonString = "bac";
    var resSB= new StringBuilder();
    foreach(var letter in inputString)
    {
    	if(replacements.ContainsKey(letter))
    		resSB.Append(replacements[letter]);
    	else
    		resSB.Append(letter);
    }
    var resString = resSB.ToString();
