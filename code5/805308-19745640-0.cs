    public static Item item = CreateItem();
    
    private static Item CreateItem()
    {
        var item = new Item() { Name = "Item" };
        item.OnBuy = client => { item.OnBuy(client); item.Name = "AAA" };
        return item;
    }
