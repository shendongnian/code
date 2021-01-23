    public string[] SplitText(string text)
    {
    var startIndex = 0;
    while (startIndex < text.Length)
    {
    	var index = text.IndexOfAny("0123456789".ToCharArray(), startIndex);
    	if (index < 0)
    	{
    		break;
    	}
    
    	var spaceIndex = text.LastIndexOf(' ', startIndex, index - startIndex);
    	if (spaceIndex != 0)
    	{
    		return new String[] { text.Substring(0, spaceIndex), text.Substring(spaceIndex + 1) };
    	}
    
    	startIndex = index;
    }
    
    return new String[] {text};
    }
