    var list = list1.Join(list2,
            x => x.Id,
            y => y.Id,
            (x, y) => Tuple.Create(x, y))
        .ToList();
    list.Foreach(tuple =>
    {
        foreach(var propertyInfo in properties)
        {
            var value1 = propertyInfo.GetValue(tuple.Item1, null);
            var value2 = propertyInfo.GetValue(tuple.Item2, null);
            if(value1 != value2)
                Console.WriteLine("Item with id {0} has different values for property {1}.",
                    tuple.Item1,Id, propertyInfo.Name);
        }
    });
