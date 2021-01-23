    var matches = dictionaries
        .Select((d, ix) => new { Dictionary = d, Index = ix })
        .Where(x => x.Dictionary.Values.Contains("specificValue"));
    
    foreach(var match  in matches)
    {
        Console.WriteLine("Index: " + match.Index);
    }
