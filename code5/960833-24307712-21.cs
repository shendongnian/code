    var list = new List<int>();
    for (int i = 0; i < 10; ++i)
    {
        var n = 1 + i;
        for (int j = 0; j < n; ++j)
        {
            var item = 1 + j;
            list.Add(item); // <- puts the current result in a list
        }
    }
    // list content: 1, 1, 2, 1, 2, 3, 1, 2, 3, 4, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 6...
    foreach (var item in list)
    { /* do something */ }
