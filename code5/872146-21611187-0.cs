    private string generateName(string name) 
    { 
    	var parts = name.Split('-');
    	int lastPart = parts.Length - 1;
        // If we have more than one part, then we have a '-' in our name
    	if(lastPart > 0)
    	{
            int count;
            // If the last "part" is a number, just increment it
    		if(int.TryParse(parts[lastPart], out count))
    		{
    			count++;	// increment counter
    			parts[lastPart] = count.ToString();
        		return string.Join("-", parts);
    		}
    	}
        // If we got here, then our string didn't end with a "-" followed by a number;
        // just append "-1" to the end.
        return name + "-1";
    }
