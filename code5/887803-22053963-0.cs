    List<Item> items = new List<Item>
    {
        new Item { Id = 1, Value = 12},
        new Item { Id = 1, Value = 900 },
        new Item { Id = 1231, Value = 0 },
        new Item { Id = 1, Value = 577 }
    };
    List<Item> nonDupes = items.GroupBy(x => x.Id).Select(x => x.First()).ToList();
    List<Item> dupes = items.Except(nonDupes).ToList();
