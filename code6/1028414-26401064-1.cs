        var list = new ArrayList {1, 2, 3};
        foreach(var n in new WrapperEnumerable<int>(list))
            Console.WriteLine(n);
        //using Cast method extension
        foreach (var n in list.Cast<int>())
            Console.WriteLine(n);
        //using OfType method extension
        foreach(var n in list.OfType<int>())
            Console.WriteLine(n);
