    public List<IItem> GetOnlineItems()
    {
        List<IItem> items = new List<IItem>();
        items.Add( new Item( "1" ) ); // Adding an instance, which implements the interface IItem
        return items;
    }
