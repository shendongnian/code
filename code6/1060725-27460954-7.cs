        var list2d = new List<Tuple<int, string>>();
        list2d.Add(new Tuple(1, "hello"));
        list2d.Add(Tuple.Create(1, "world");
        foreach (var item in lists2d)
        {
            Console.WriteLine(string.Format("{0}: {1}", item.Item1, item.Item2);
        }
