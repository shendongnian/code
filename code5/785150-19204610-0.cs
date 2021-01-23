    string[] filenames = {
    "somefile1x01description.ext",
    "sometext01x01description.ext",
    "sometext101description.ext",
    "sometextS01Edescription.ext",
    "sometextS01 Edescription.ext",
    "sometextS1Edescription.ext",
    "sometextS1 Edescription.ext",
    "sometextS1xdescription.ext"
    };
    
    string re1 = @"(?<season>\d{1,2})(?<episode>\d{2})";  // Handles the case where you just have a 3 or 4 digit number
    string re2 = @"[sS]?(?<season>\d+)[ xXeE]*(?<episode>\d*)"; // Handles the cases where you have a delimiter
    
    MatchEvaluator reFunc = match => // Given a Regex Match object
    // An expression that returns the replacement string
    "S" + // Start with the S
    match.Groups["season"].Value // get the season group
    .PadLeft(2,'0') + // zero pad it
    "E" + // Add the E
    (match.Groups["episode"].Value.Length > 0 ? // Is there an episode number?
    match.Groups["episode"].Value.PadLeft(2,'0') : // If so, zero pad it
    "01" // Otherwise assume episode 01
    ); // End replacement expression
    
    foreach(string name in filenames)
    {
    	string replaced = name;
    	if(Regex.IsMatch(name,re1))
    	{
    		replaced = Regex.Replace(name,re1,reFunc);
    	}
    	else if (Regex.IsMatch(name,re2))
    	{
    		replaced = Regex.Replace(name,re2,reFunc);
    	}
    
    	Console.WriteLine("Orig: {0} Replaced: {1}",name,replaced);
    }
