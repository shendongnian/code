    public Item CreateItem(string name)
    {
        return new Item(name);
    }
    public Task<Item> CreateItemAsync(string name)
    {
        return Task.Factory.StartNew(() => CreateItem(name));
    }
