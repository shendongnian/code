    public List<Item> GetFirstItems()
    {
        return items.Collection.Take(50);
    }
    public Item GetOtherItems(int skip)
    { 
         return items.Collection.Skip(skip).Take(25)
    }
