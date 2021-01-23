    List<Item> items = new List<Item>()
    {
        new Item() { Name = "Item01", Quantity = 40 }, // 130
        new Item() { Name = "Item01", Quantity = 70 },
        new Item() { Name = "Item01", Quantity = 10 },
        new Item() { Name = "Item01", Quantity = 10 },
        new Item() { Name = "Item02", Quantity = 50 }, // 100
        new Item() { Name = "Item02", Quantity = 50 },
        new Item() { Name = "Item03", Quantity = 10 }  // 10
    };
    var result =
        // Group by Name, calculate total sum for each group
        items.GroupBy(i => i.Name, (k, v) => new Item()
        {
            Name = k,
            Quantity = v.Sum(i => i.Quantity)
        })
        // Split groups into 100 packages
        .SelectMany(i => Enumerable.Range(0, (int)Math.Ceiling(i.Quantity / 100.0))
                                   .Select(n => new Item()
        {
            Name = i.Name,
            Quantity = i.Quantity > ((n + 1) * 100) ? 100 : i.Quantity - n * 100
        }))
        .ToList();
