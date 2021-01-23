    public void SetAllItems()
    {
        foreach (DatabaseEntryBase entry in EntryCollection)
        {
            entry.ModifiedTime = [...];
            entry.IsDeleted = [...]
        }
    }
