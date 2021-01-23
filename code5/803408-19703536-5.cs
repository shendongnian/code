    Items = new ObservableCollection<Item>();
    foreach (string value in values)
    {
        Item item = new Item() { Name = value };
        foreach (SomeType someType in SomeTypes.Where(s => s.Something == value))
        {
            item.ItemCollection.Add(someType);
        }
        Items.Add(item);
    }
