    public void SetAllItems()
    {
        foreach (DatabaseEntryBase entry in EntryCollection)
        {
            entry.ModifiedTime = DateTime.Now;
            entry.IsDeleted = [...];
        }
    }
