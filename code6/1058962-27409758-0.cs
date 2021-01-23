    string input = "This is a sentence\nand the continuation of the sentence.\n\nLet's go for\na second time.";
    
    var rx = new Regex(@"\w(\n)\w");
    
    var output = new StringBuilder();
    
    int marker = 0;
    
    var allMatches = rx.Matches(input);
    foreach (var match in allMatches.Cast<Match>())
    {
    	output.Append(input.Substring(marker, match.Groups[1].Index - marker));
    	output.Append(" ");
    	marker = match.Groups[1].Index + match.Groups[1].Length;
    }
    output.Append(input.Substring(marker, input.Length - marker));
    
    Console.WriteLine(output.ToString());
