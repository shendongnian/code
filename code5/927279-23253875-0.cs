    public void Addwords(string input)
    {
        Regex.Match = Regex.Match(input, "^[a-zA-Z.]{2,10}$");
        if (match.Success)
        {
	        word.add(input);
        }
    }  
