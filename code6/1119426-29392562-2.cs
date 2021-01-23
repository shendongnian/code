    Func<Item, Item> withCalculatedValue =
        item => {
            item.CalculatedValue = item.Name + item.Value;
            return item;
        };
    return items.GroupBy(i => i.Value)
            .Select(x => new Item(x.First().Name, x.Key))
            .Select(withCalculatedValue);
