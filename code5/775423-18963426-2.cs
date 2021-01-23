    var results = myContext.SpecificTable.Where(c => lines.Contains(c.ItemNumber)).Select(c => new {c.ItemNumber, c.Description}).ToList();
    foreach(var result in results)
    {
        Console.WriteLine(string.format("{0}:{1}", "Description", result.Description));
    }
