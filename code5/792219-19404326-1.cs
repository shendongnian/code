    var dict = s.GroupBy(i => i).ToDictionary(g => g.Key, g => g.Count());
    foreach (var g in dict)
    {
        Console.WriteLine( "{0}: {1}", g.Key, g.Value );
    }
