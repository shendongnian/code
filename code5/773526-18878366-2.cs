    var list = new List<int>();
    var prop1 = new PropertyWrapper<int>(
        () => list.Capacity, cap => list.Capacity = cap);
    var prop2 = PropertyWrapper.Create(list, l => l.Capacity);
    prop2.Value = 42;
    Console.WriteLine(list.Capacity); //prints 42
