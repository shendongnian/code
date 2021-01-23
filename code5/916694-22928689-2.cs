    items.ToList().ForEach(i => testItems.Add(
    new TestItem
    {
        Header = i.TestItemTypeName,
        Content = i
    }));
