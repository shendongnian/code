    Dictionary< string, Dictionary< string, string>> myDict=new Dictionary< string, Dictionary< string, string>>();
     
    public void Add(string s, Dictionary< string, string> Dict)
    {
        if (!myDict.ContainsKey(s))
        {
            myDict.Add(s,Dict)
        }
    }
