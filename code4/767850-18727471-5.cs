    var dupes = 
        lines.GroupBy(l => l)
             .Select(g => new { Value = g.Key, Count = g.Count() })
             .Where(g => g.Count > 1);
    foreach (var d in dupes)
    {
        Console.WriteLine("'{0}' is a dupe.", d.Key);
    }
