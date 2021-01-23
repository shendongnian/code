    static void Main(string[] args)
    {
    	List<String> test = new List<string> {
    		"Const foo = 123",
    		"Const foo$ = \"123\"",
            "Const foo As String = \"1'2'3\"",
    		"Const foo As String = \"123\"",
    		"Private Const foo = 123",
    		"Public Const foo As Integer = 123",
    		"Global Const foo% = 123",
    		"Const foo = 123 'this comment is included as part of the value",
    		"Const foo = 123, bar = 456",
    		"'Const foo As String = \"123\"",
    	};
    
    
    	foreach (var str in test)
    		Parse(str);
    
    	Console.Read();
    }
    
    private static Regex parse = new Regex(@"^(?:(?<Accessibility>Private|Public|Global)\s)?Const\s(?<variable>[a-zA-Z][a-zA-Z0-9_]*(?:[%&@!#$])?(?:\sAs)?\s(?:(?:[a-zA-Z][a-zA-Z0-9_]*)\s)?=\s[^',]+(?:(?:(?!"").)+"")?(?:,\s)?){1,}(?:'(?<comment>.+))?$", RegexOptions.Compiled | RegexOptions.Singleline, new TimeSpan(0, 0, 20));
    private static Regex variableRegex = new Regex(@"(?<identifier>[a-zA-Z][a-zA-Z0-9_]*)(?<specifier>[%&@!#$])?(?:\sAs)?\s(?:(?<reference>[a-zA-Z][a-zA-Z0-9_]*)\s)?=\s(?<value>[^',]+(?:(?:(?!"").)+"")?),?", RegexOptions.Compiled | RegexOptions.Singleline, new TimeSpan(0, 0, 20));
    
    public static void Parse(String str)
    {
    	Console.WriteLine(String.Format("Parsing: {0}", str));
    
    	var match = parse.Match(str);
    
    	if (match.Success)
    	{
    		//Private/Public/Global
    		var accessibility = match.Groups["Accessibility"].Value;
    		//Since we defined this with atleast one capture, there should always be something here.
    		foreach (Capture variable in match.Groups["variable"].Captures)
    		{
    			//Console.WriteLine(variable);
    			var variableMatch = variableRegex.Match(variable.Value);
    			if (variableMatch.Success) 
    			{
    				Console.WriteLine(String.Format("Identifier: {0}", variableMatch.Groups["identifier"].Value));
    
    				if (variableMatch.Groups["specifier"].Success)
    					Console.WriteLine(String.Format("specifier: {0}", variableMatch.Groups["specifier"].Value));
    
    				if (variableMatch.Groups["reference"].Success)
    					Console.WriteLine(String.Format("reference: {0}", variableMatch.Groups["reference"].Value));
    
    				Console.WriteLine(String.Format("value: {0}", variableMatch.Groups["value"].Value));
    
    				Console.WriteLine("");
    			}
    			else
    			{
    				Console.WriteLine(String.Format("FAILED VARIABLE: {0}", variable.Value));
    			}
    
    		}
    
    		if (match.Groups["comment"].Success)
    		{
    			Console.WriteLine(String.Format("Comment: {0}", match.Groups["comment"].Value));
    		}
    	}
    	else
    	{
    		Console.WriteLine(String.Format("FAILED: {0}", str));
    	}
    
    	Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++");
    	Console.WriteLine("");
    }
