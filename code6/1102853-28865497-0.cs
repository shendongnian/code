    void ReplaceIfNotEmpty(ref string destination, string source)
    {
    	if (!string.IsNullOrEmpty(source))
    	{
    		destination = source;
    	}
    }
