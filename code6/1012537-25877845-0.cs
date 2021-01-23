    var items = new List<Item>
    {
        new Item {index = 1, generator_list = new HashSet<string> {"1", "2"}},
        new Item {index = 2, generator_list = new HashSet<string> {"2", "3"}}
    };
    var newItem = new Item { index = 3, generator_list = new HashSet<string> { "1", "2" } };
    var intersects = items.AsParallel()
        .Select(item => new
        {
            index = item.index,
            intersects =
                item.generator_list.AsParallel()
                .Join(newItem.generator_list.AsParallel(),
                    s => s, s => s, (s, s1) => s == s1)
                    .Count()
        });
