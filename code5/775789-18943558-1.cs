    var list = new List<Tuple<string, string>>();
    list.Add(new Tuple<string, string>("test1", "2"));
    list.Add(new Tuple<string, string>("test1", "1"));
    list.Add(new Tuple<string, string>("test2", "1"));
    list.Add(new Tuple<string, string>("test2", "6"));
    list.GroupBy(x => x.Item1)
        .Select(x => 
                new {
                    a = x.Key,
                    b = x.OrderByDescending(y => y).First(),
                    c = x.Count()
                }
        ).ToList()
