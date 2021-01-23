    string[] filenames = {
    "1000 Ways to Die S01E01 Life Will Kill You",
    "somefile1x01description.ext",
    "sometext01x01description.ext",
    "sometext101description.ext",
    "sometextS01Edescription.ext",
    "sometextS01 Edescription.ext",
    "sometextS1Edescription.ext",
    "sometextS1 Edescription.ext",
    "sometextS1xdescription.ext",
    "24 S01xE01 12 AM"
    };
    
    string [] res = {
    	@"[sS]?(?<season>\d{1,2})[ xXeE]+(?<episode>\d{1,2})", // Handles the cases where you have a delimiter and a digit on both sides, optional S
    	@"[sS](?<season>\d{1,2})[ xXeE]+(?<episode>\d{0,2})", // Handles the cases where you have a delimiter, a required S, but optional episode number
    	@"(?<season>\d{1,2})(?<episode>\d{2})"  // Handles the case where you just have a 3 or 4 digit number
    };
    
    MatchEvaluator reFunc = match => // Given a Regex Match object
    // An expression that returns the replacement string
    "S" + // Start with the S
    match.Groups["season"].Value // get the season group
    .PadLeft(2,'0') + // zero pad it
    "xE" + // Add the E
    (match.Groups["episode"].Value.Length > 0 ? // Is there an episode number?
    match.Groups["episode"].Value.PadLeft(2,'0') : // If so, zero pad it
    "01" // Otherwise assume episode 01
    ); // End replacement expression
    
    foreach(string name in filenames)
    {
    	Console.WriteLine("Orig: {0}",name);
    	string replaced = name;
    	
    	foreach (string re in res)
    	{
    		Console.WriteLine("Trying:" + re);
    		if(Regex.IsMatch(name,re))
    		{
    			Console.WriteLine("Matched");
    			replaced = Regex.Replace(name,re,reFunc);
    			break;
    		}
    	}
    	Console.WriteLine("Replaced: {0}\n\n",replaced);
    }
