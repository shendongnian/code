    var list = new List<Tuple<int,string>>();
            
    list.Add(Tuple.Create(1, "Andy"));
        
    foreach (var item in list)
    {
        Console.WriteLine(item.Item1.ToString());
        Console.WriteLine(item.Item2);
    }
