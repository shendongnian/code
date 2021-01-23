    var text = "Hello world, this is a great test!";
    var badWords = new List<string>()
    {
        "Hello", 
        "great"
    };
    
    var wordMatches = Regex.Matches(text, "\\w+")
        .Cast<Match>()
        .OrderByDescending(m => m.Index);
    
    foreach (var m in wordMatches)
        if (badWords.Contains(m.Value))
            text = text.Remove(m.Index, m.Length);
    
    Debug.WriteLine(text);
