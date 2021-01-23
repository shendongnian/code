    string str = "FixedLines Rs. 0.200 / 1 min Rs. 0.600 / 1 min";
    var parts = str.Split(new[] { " Rs. " }, StringSplitOptions.RemoveEmptyEntries)
        .Where(p => p.Contains("/"));
    foreach(string part in parts)
        Console.WriteLine(part);
