    static void Main(string[] args)
    {
        Item item1 = new Item() { CreatedDate = new DateTime(2010, 11, 10), Id = "1", Name = "foo1", Price = "10.00" };
        Item item2 = new Item() { CreatedDate = new DateTime(2010, 11, 11), Id = "2", Name = "foo2", Price = "11.00" };
        Item item3 = new Item() { CreatedDate = new DateTime(2010, 11, 12), Id = "3", Name = "foo3", Price = "12.00" };
        Item item4 = new Item() { CreatedDate = new DateTime(2010, 11, 13), Id = "4", Name = "foo4", Price = "13.00" };
        Item item5 = new Item() { CreatedDate = new DateTime(2010, 11, 14), Id = "5", Name = "foo5", Price = "14.00" };
        Item item6 = new Item() { CreatedDate = new DateTime(2010, 11, 15), Id = "6", Name = "foo6", Price = "15.00" };
        Item item7 = new Item() { CreatedDate = new DateTime(2010, 11, 16), Id = "7", Name = "foo7", Price = "16.00" };
        Item item8 = new Item() { CreatedDate = new DateTime(2010, 11, 17), Id = "8", Name = "foo8", Price = "17.00" };
        List<Item> items = new List<Item>();
        items.Add(item1);
        items.Add(item2);
        items.Add(item3);
        items.Add(item4);
        items.Add(item5);
        items.Add(item6);
        items.Add(item7);
        items.Add(item8);
        List<Item> filtered = ItemsBeforeDate(items, new DateTime(2010, 11, 16));
        foreach (Item i in filtered)
        {
            Console.Write(i.Name);
        }
        Console.Read();
    }
    public static List<Item> ItemsBeforeDate(List<Item> items, DateTime beforeDate)
    {
        return items.Where(i => i.CreatedDate < beforeDate).ToList();
    }
    public static List<Item> ItemsAfterDate(List<Item> items, DateTime afterDate)
    {
        return items.Where(i => i.CreatedDate > afterDate).ToList();
    }
    public static List<Item> ItemsBetweenDates(List<Item> items, DateTime startDate, DateTime endDate)
    {
        return items.Where(i => i.CreatedDate >= startDate && i.CreatedDate <= endDate).ToList();
    }
