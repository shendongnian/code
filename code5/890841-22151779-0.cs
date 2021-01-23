    public string CleanField(string input)
    {
    	if (input.StartsWith("\"") && input.EndsWith("\""))
    	{
    		string output = input.Substring(1,input.Length-2);
    		output = output.Replace("\"\"","\"");
    		return output;
    	}
    	else
    	{
    		//If it doesn't start and end with quotes then it doesn't look like its been escaped so just hand it back
    		return input;
    	}
    }
