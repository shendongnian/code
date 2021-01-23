    var dictionary = new Dictionary<string, int>(5);
    dictionary.Add("cat", 1);
    dictionary.Add("dog", 0);
    dictionary.Add("mouse", 5);
    dictionary.Add("eel", 3);
    dictionary.Add("programmer", 2);
    var orderedPairs = dictionary.OrderBy(pair => pair.Value);
    foreach (var pair in orderedPairs)
        Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
