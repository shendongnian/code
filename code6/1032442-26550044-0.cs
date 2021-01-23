    public virtual void CreateIndex(string[] fields)
    {
        foreach (string field in fields)
        {
            if (!Repository.IndexExists(field))
            {
                Repository.EnsureIndex(new IndexKeysBuilder().Ascending(field), IndexOptions.SetUnique(true).SetSparse(true));
            }
        }
    }
