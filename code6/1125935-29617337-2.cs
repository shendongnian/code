    public string CleanWord(string word)
    {
    	//Remove everything but letters, numbers and whitespace characters
    	word = Regex.Replace(word, @"[^\w\s]", string.Empty);
    	
    	//Remove multiple whitespace characters
    	word = Regex.Replace(word, @"\s+", " ");
    	
    	//remove any digits
    	word = Regex.Replace(word, @"[\d-]"," ");
    	
    	return word.Trim();
    }
