    string[] Parse(string line)
    {
    	var chars = new List<char>(); // characters since last whitespace
    	var all = new List<char>();
    	
    	using(var i = line.GetEnumerator())
    	while(i.MoveNext())
    	{
    		var current = (char)i.Current;
    		
    		// keep track of characters since last whitespace
    		if (current == ' ')      chars.Clear();
    		else if (current != '|') chars.Add(current);
    		
    		// read until first pipe
    		if(current == '|')
    			return BuildResult(i, all, chars);
    		
    		all.Add(current);
    	}
    	
    	return new String[]{};
    }
    
    string[] BuildResult(IEnumerator i, List<char> all, List<char> chars)
    {
    	var rest = (new[]{'|'}).Concat(ReadRemaining(i));
    	var diff = all.Count - chars.Count;
    	
    	IEnumerable<char> start = chars;
    	IEnumerable<char>   end = rest;
    	if(diff != 0)
    	{
    		// if there was a whitespace, the chars 
    		// before | belong to group 1
    		start = all.Take(diff);
    		end = chars.Concat(rest);
    	}
    		
    	return new []{new String(start.ToArray()), new String(end.ToArray())};
    
    }
    
    string ReadRemaining(IEnumerator i)
    {
    	var rest = new List<Char>();
    	while(i.MoveNext())
    		rest.Add((char)i.Current);
    	return new String(rest.ToArray());
    }
