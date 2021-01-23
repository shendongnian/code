    var groupedItems = items.GroupBy(i => i.Value)
        .Select(x => 
        {
            Console.WriteLine("Creating new item");
            return new Item(x.First().Name, x.Key));
        }
    foreach(var item in groupedItems);
    foreach(var item in groupedItems);
