    var result = _cells
        //             here         and capture it in an object
        //              |
        .Select((Item, Index) => new { Item, Index })
        .FirstOrDefault(itemWithIndex => itemWithIndex.Item.Column == 5);
    Console.WriteLine($"The index of column 5 is {result?.Index}");
