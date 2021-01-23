    var numDuplicates = File.ReadLines(path)
        .Select(l => l.Trim().Split(','))
        .Where(arr => arr.Length >= 3)
        .Select(arr => new { 
            Number = arr[0].Trim(),
            Name   = arr[1].Trim(),
            Age    = arr[2].Trim()
        })
        .GroupBy(x => x.Number)
        .Where(g => g.Count() > 1);
    
    foreach(var dupNumGroup in numDuplicates)
        Console.WriteLine("Number:{0} Names:{1} Ages:{2}"
            , dupNumGroup.Key
            , string.Join(",", dupNumGroup.Select(x => x.Name))
            , string.Join(",", dupNumGroup.Select(x => x.Age)));
