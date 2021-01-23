    static Dictionary<char, string> wordMap = new Dictionary<char, string>()
    {
        {'a', "Alpha"}, {'b', "Beta"},{'c', "Gamma"}, {'d', "Delta"}
    };
    static string WordMap(string value)
    {
        var strings = value
            .Select(c => 
            {
                string word; 
                if(!wordMap.TryGetValue(c, out word))
                    word = c.ToString();
                return word;
            });
        return string.Join("", strings);
    }
