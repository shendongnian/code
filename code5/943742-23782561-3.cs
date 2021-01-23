    var houses = ppl.GroupBy(x => x.houseid)
                    .Where(g => g.Count() < 5)
                    .Select(g => new { Id = g.Key, Count = g.Count());
    foreach (var house in houses)
    {
        Console.WriteLine("House {0} has a population of {1}", house.Id, house.Count);
    }
