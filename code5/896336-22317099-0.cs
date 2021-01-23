    var items = new[] {"ItemA", "ItemB", "ItemC", "ItemD", "ItemE"};
    //option 1 - most intuative.
    foreach (var item in items)
    {
        Console.WriteLine(item);
        //other instructions of the iteration..
    }
    //option 2 - full control over the iterator.
    for (var index = 0; index < items.Length; index++)
    {
        var item = items[index];
        Console.WriteLine(item);
        //other instructions of the iteration..
    }
    //option 3a - shortest, modern.. but also less efficient due to the casting.
    items.ToList().ForEach(Console.WriteLine);
    //option 3b - same as 3a but can have more instructions inside..
    items.ToList().ForEach(item =>
    {
        Console.WriteLine(item);
        //other instructions of the iteration..
    });
