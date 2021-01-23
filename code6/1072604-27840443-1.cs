    public int LetterCount(string filename, char letter)
    {
    	int cnt = 0;
    	string source = File.ReadAllText(filename);
        //Check every character in your string; if it matches increase the counter by 1
    	foreach (char c in source)
    	{
    		if(c == letter)
    		{
    			cnt++;
    		}
    	}
    	return cnt;
    }
