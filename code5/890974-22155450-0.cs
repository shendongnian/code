    static string inputStr = "# preceding comment \r\n" + 
    "class\r\n" + 
    "{\r\n" + 
    "   (param1 = \"val1\", param2 = \"val2\", param3 = val3)\r\n" + 
    "}\r\n" + 
    "[\r\n" + 
    "    # inside comment\r\n" + 
    "    setting1 = 0;\r\n" + 
    "    setting2 = 0;\r\n" + 
    "]\r\n";
    
    const string REGEX = "(\\= [0]\\;)";
    
    void Main()
    {
    	
    	var regex = new System.Text.RegularExpressions.Regex(REGEX);
    	MatchCollection matches = regex.Matches(inputStr);
    	Console.WriteLine("Matches:{0}", matches.Count);
    	int matchCnt = 0;
    	foreach (Match m in matches)
    	{
    		int groupCnt = 0;
    		foreach (Group g in m.Groups)
    		{
    			Console.WriteLine("match[{0}] group[{1}]: Captures:{2} '{3}'", matchCnt, groupCnt, g.Captures.Count, g);
    			//g.Dump();
    			groupCnt++;
    		}
    		matchCnt++;
    	}
    	Console.WriteLine("Done!");
    }
