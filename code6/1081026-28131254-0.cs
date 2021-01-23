    public static Dictionary<IPerson, string> AddRange<TPerson>(
                        this Dictionary<IPerson, string> dict, 
                        Dictionary<TPerson, string> inputDict)
        where TPerson : IPerson
    {
        foreach (var kvp in inputDict)
        {
            dict.Add(kvp.Key, kvp.Value);
        }
    
        return dict;
    }
