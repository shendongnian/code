    var names = myClass1List
        .SelectMany(c1 => c1.Class2List.Where(c2 => c2.Name == "something"))
        .SelectMany(c2 => c2.Class3List.Select(c3 => c3.Name));
    var names = myClass1List
        .SelectMany(c1 => c1.Class2List
            .Where(c2 => c2.Name == "something")
            .SelectMany(c2 => c2.Class3List
                .Select(c3 => c3.Name)));
