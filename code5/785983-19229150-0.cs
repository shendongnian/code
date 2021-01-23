    var lists = new List<List<string>>();
    lists.Add(new List<string>(new string[] { "Test1", "Test2", "Test3" }));
    lists.Add(new List<string>(new string[] { "Test1", "Test2", "Test4" }));
    lists.Add(new List<string>(new string[] { "Test1", "Test2", "Test5" }));
    lists.Add(new List<string>(new string[] { "Test1", "Test2", "Test6" }));
    var aggregate = lists.Aggregate((x, y) => x.Intersect(y).ToList());
