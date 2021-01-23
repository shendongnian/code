    var my_string = "In the end this is not the end";
    int step = 2;
    string[] words = my_string.Split();
    var groupWords = new List<string[]>();
    for (int i = 0; i + step < words.Length; i++)
    {
        string[] group = new string[step];
        for (int ii = 0; ii < step; ii++)
            group[ii] = words[i + ii];
        groupWords.Add(group);
    }
    var lookup = groupWords
        .ToLookup(w => string.Join(" ", w));
    foreach (var kv in lookup)
        Console.WriteLine("Key: \"{0}\", Count: {1}", kv.Key, kv.Count()); 
