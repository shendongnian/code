    public ItemList()
    {
        Initialize();
    }
    public async void Initialize()
    {
        await ReadStuff();
        item.Add(new Items() { ItemID = x1, ItemTitle = x2, ItemBody = x3 });
    }
