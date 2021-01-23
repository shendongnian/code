    if (items.entry != null && items.entry.Count > 0)
    {
        foreach(Entry entryItem in items.entry)
        {
            if (!string.IsNullOrEmpty(entryItem.id))
            {
                string paymentID = entryItem.id;
            }
        }
    }
