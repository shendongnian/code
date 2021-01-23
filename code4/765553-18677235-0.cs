    var id = new string[] { "SS41231" }.AsQueryable();
    // *it* represents the current element
    var res = id.Where("it.Length > @0 AND it.Substring(@1, @2) = @3", 1, 0, 2, "SS"); // Save the result, don't throw it away.
    if (res.Any())
    {
        // Line below in normal LINQ: string newID = res.Select(x => "98" + x.Substring(2)).First();
        string newId = res.Select("@0 + it.Substring(@1)", "98", 2).Cast<string>().First();
        Console.WriteLine(newId);
    }
