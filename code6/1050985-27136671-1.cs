    List<int> list = new List<int> { 1, 2, 3, 2, 1, 6, 2 };
    var query = list.GroupBy(item => item)
                    .OrderByDescending(grp => grp.Count())
                    .Select(grp => grp.Key);
    foreach (var item in query)
    {
        Console.WriteLine(item);
    }
