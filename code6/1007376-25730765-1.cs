    var items = new List<Item>
    {
        new Item {Color = "Green", Id = 1},
        new Item {Color = "Red", Id = 1},
        new Item {Color = "Red", Id = 2},
        new Item {Color = "Green", Id = 3},
        new Item {Color = "Red", Id = 4},
        new Item {Color = "Green", Id = 4},
    };
    var q = items.GroupBy(x => x.Id)
                 .Select(group => new 
                         {
                             Id = group.Key, 
                             Green = group.Any(item => item.Color == "Green"), 
                             Red = group.Any(item => item.Color == "Red") 
                         });
