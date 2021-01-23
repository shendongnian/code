    var results = myContext.SpecificTable.Select(c => lines.Contains(c.ItemNumber)).ToList();
    foreach(var result in results)
    {
        Console.WriteLine(string.format("{0}:{1}", "Description", result.Description));
    }
