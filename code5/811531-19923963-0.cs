    public bool ContainsItem(string word, string[] array)
    {
        foreach(string s in array)
            if(word.Contains(s))
                return true;				
        return false;
    }
    
    //Usage:
    var result = ContainsItem(str, strArr);
