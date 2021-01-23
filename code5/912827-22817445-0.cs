    var query = items.GroupBy(item => item.Id)
        .Select(group => new Item
        {
            Id = group.Key,
            Orders = group.SelectMany(item => item.Orders).ToList()
        });
