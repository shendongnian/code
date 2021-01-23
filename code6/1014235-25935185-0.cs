    public Dictionary<string, Answer> AnswserKeywordDictionary { get; set; }
    public GetAnswer(string key, Answer defaultValue)
    {
       if(AnswserKeywordDictionary.ContainsKey(key)
           return AnswserKeywordDictionary[key];
       return defaultValue;
    }
