    public static string ForPlayer(string originalString, object player)
    {
    	var type = player.GetType();
    	var sb = new StringBuilder(originalString.Length);
    	var lastEnd = 0;	// after the last close brace
    	var start = originalString.IndexOf('{');	// start brace
    	while (start != -1)	// go until we run out of open braces
    	{
    		var end = originalString.IndexOf('}', start + 1);	// end brace
    		if (end == -1)	// if there's a start brace but no end, just quit
    			break;
    		// copy from the end of the last string to the start of the new one
    		sb.Append(originalString, lastEnd, start - lastEnd);
    		// get the name of the property to look up
    		var propName = originalString.Substring(start + 1, end - start - 1);
    		// add in the property value
    		sb.Append(type.GetProperty(propName).GetValue(player, null));
    		lastEnd = end + 1;	// move the pointer to the end of the last string
    		start = originalString.IndexOf('{', lastEnd);	// find the next start
    	}
    	// copy the end of the string
    	sb.Append(originalString, lastEnd, originalString.Length - lastEnd);
    	return sb.ToString();
    }
