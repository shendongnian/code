    public string RemoveCharactersBeforeUnderscore(string s)
    {
     string splitted=s.Split('_');
     return splitted[splitted.Length-1]
    }
