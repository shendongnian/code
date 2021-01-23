    static void Main(string[] args)   
    { 
        var inputList = new List<string>
        {
            "John likes pancakes",
            "John hates watching TV",
            "I like my TV",
        };
    
        var dic = new Dictionary<string, int>();
        inputList.ForEach(str => AddToDictionary(dic, str));
    
        foreach (var entry in dic)
            Console.WriteLine(entry.Key + ": " + entry.Value);
    }
    static void AddToDictionary(Dictionary<string, int> dictionary, string input)
    {
        input.Split(' ').ToList().ForEach(n =>
        {
            if (dictionary.ContainsKey(n))
                dictionary[n]++;
            else
                dictionary.Add(n, 1);
        });
    }
