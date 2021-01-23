    public void AttachKeywords(int itemId, List<string> keywords, DbSet tableEntity, DbSet joinTableEntity)
    {
        // ...
        foreach (var keyword in keywords)
        {
            tableEntity.Add(keyword);
            myDbContext.SaveChanges();
        }
        // ...
    }
