    public void Save(Item item)
    {
        SaveToDatabase(item);
        Item cached = LastValueCache;
        if (cached == null || item.Stamp > cached.Stamp)
        {
            LastValueCache = item;
        }
    }
