    void Main()
    {
    	var input = "Test0 \"Test1 Test2\" \"Test3 Test4";
    	var parts = new Parser().ParseString(input);
    	foreach(var part in parts)
    		Console.WriteLine(part);
    	var searchString = string.Join(" AND ", parts);
    	Console.WriteLine("SearchString = " + searchString);
    }
    
    public class Parser
    {
    	public IEnumerable<string> ParseString(string input)
    	{
    		// Split by blanks
    		var parts = input.Split(' ');
    		var consolidatedParts = new List<string>();
    		for(int i = 0; i < parts.Length; i++)
    		{
    			var part = parts[i];
    			// If part starts a block of quotes, add the following parts 
    			// until either a closing quotation mark is found or the end 
    			// is reached
    			if (part.StartsWith("\""))
    			{
    				while (++i < parts.Length)
    				{
    					part += " " + parts[i];
    					if (parts[i].EndsWith("\""))
    						break;
    				}
    				if (!part.EndsWith("\""))
    					part += "\"";
    			}
    			consolidatedParts.Add(part);
    		}
    		return consolidatedParts.AsReadOnly();
    	}
    }
