    public IEnumerable<Item> GetItems()
    {
        foreach(Item i in List)
        {
            if conditions are met
            {
                yield return i;
            }
        }
    }
