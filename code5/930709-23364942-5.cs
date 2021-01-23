    List<List<int>> lists = new List<List<int>>();
    lists.Add(new List<int> { 1 });
    lists.Add(new List<int> { 2,3 });
    lists.Add(new List<int> { 4,5,6 });
    List<List<int>> result = lists.Pivot();
    foreach(List<int> list in result)
        Console.WriteLine(string.Join(",", list));
