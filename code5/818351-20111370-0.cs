    static void Main(string[] args)
    {
    
        List<string> wordsList = new List<string>()
        {
            "Cat",
            "Dog",
            "Cat",
            "Hat"
        };
    
        List<WordCount> usd = wordsList.GroupBy(x => x)
                                       .Select(x => new WordCount() { wordDic = x.Key, count = x.Count() })
                                       .ToList();
    }
