    var theList = new List<string>() { "Alpha", "Alpha", "Beta", "Gamma", "Delta" };
    theList.GroupBy(txt => txt)
        .Where(grouping => grouping.Count() > 1)
        .ToList()
        .ForEach(groupItem => Console.WriteLine("{0} duplicated {1} times with these values {2}",
             groupItem.Key,
             groupItem.Count(),
             string.Join(" ", groupItem.ToArray())));
            Console.ReadKey();
