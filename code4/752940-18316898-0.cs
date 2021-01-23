    var source = new List<Item>(9) {
        new Item { Name1 = "A", Name2 = "One", Price = 10, SubName = "X", SubPrice = 5},
        new Item { Name1 = "A", Name2 = "One", Price = 10, SubName = "Y", SubPrice = 7},
        new Item { Name1 = "A", Name2 = "One", Price = 10, SubName = "Z", SubPrice = 11},
        new Item { Name1 = "A", Name2 = "One", Price = 10, SubName = "X", SubPrice = 5},
        new Item { Name1 = "A", Name2 = "One", Price = 10, SubName = "Y", SubPrice = 7},
        new Item { Name1 = "A", Name2 = "One", Price = 10, SubName = "Z", SubPrice = 11},
        new Item { Name1 = "A", Name2 = "Two", Price = 16, SubName = "X", SubPrice = 5},
        new Item { Name1 = "A", Name2 = null, Price = 9, SubName = null, SubPrice = 0 },
        new Item { Name1 = "B", Name2 = "three", Price = 24, SubName = null, SubPrice = 0}
    };
    var grouped = source.GroupBy(x => new { x.Name1, x.Name2 })
                        .Select(g => new
                        {
                            Name = string.Format("{0} {1} {2}", g.Key.Name1, g.Key.Name2, string.Join(", ", g.Select(x => x.SubName))).Trim(),
                            Quantity = g.Count() / g.Select(x => x.SubName).Distinct().Count()
                        })
                        .ToList();
