    var query = setOfPersons
        .SelectMany(l => l.Select(l1 => l1))
        .GroupBy(p => p.Id)
        .Where(g => g.Count() == setOfPersons.Count)
        .Select(x=>x.First())             // Select first person from the grouping - they all are identical
        .ToList();
	
    Console.WriteLine("These people appears in all set:");
    foreach (var a in query)
    {
        Console.WriteLine("Id: {0} Name: {1}", a.Id, a.Name);
    }
