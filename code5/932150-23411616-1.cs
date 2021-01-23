    List<ItemType> items = new List<ItemType>();
    while (!inputQueue.IsCompleted)
    {
        ItemType t;
        while (inputQueue.TryTake(out t, TimeSpan.FromSeconds(5))
        {
            items.Add(t);
        }
        if (items.Count > 0)
        {
            // Add this list of items to the intermediate queue
            intermediateQueue.Add(items);
            items = new List<ItemType>();
        }
    }
