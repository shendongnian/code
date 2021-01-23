    Dictionary<string, Dictionary<string, Dictionary<string, string>>> dictionary =
        new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();
    if (dictionary.ContainsKey("someKey"))
    {
        var secondDictionary = dictionary["someKey"];
        if (secondDictionary.ContainsKey("otherKey"))
        {
            var thirdDictionary = secondDictionary["otherKey"];
            if (thirdDictionary.ContainsKey("thirdKey"))
            {
                var final = thirdDictionary["thirdKey"];
            }
        }
    }
