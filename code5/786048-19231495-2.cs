    var list = new List<Tuple<int,string>>();
           
    list.Add(Tuple.Create(1, "Andy"));
    list.Add(Tuple.Create(1, "John"));
    list.Add(Tuple.Create(3, "Sally"));
        
    foreach (var item in list)
    {
        Console.WriteLine(item.Item1.ToString());
        Console.WriteLine(item.Item2);
    }
