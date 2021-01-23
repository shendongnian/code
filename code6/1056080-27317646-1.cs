    var matches = dictionaries
        .Select((d, ix) => new { Dictionary = d, Index = ix })
        .Where(x => x.Dictionary.Values.Contains("specificValue")); // or ContainsValue as the Eric has shown
    
    foreach(var match in matches)
    {
        Console.WriteLine("Index: " + match.Index);
    }
