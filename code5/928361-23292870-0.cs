    string str = "this is is a string";
    string[] words = str.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
    Dictionary<string, int> statistics = words
        .GroupBy(word => word)
        .ToDictionary(
            kvp => kvp.Key, // the word itself is the key
            kvp => kvp.Count()); // number of occurences is the value
    int isCount = statistics["is"]; // returns 2
