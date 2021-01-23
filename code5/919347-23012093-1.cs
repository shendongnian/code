    public void InsertOrUpdate(EbayCategory entity)
    {
        if(Find(entity.ID == null)
        {
             // New entity
             DbSet<EbayCategory>().Add(entity);
        }
        else
        {
             // Existing entity
             _database.Entry(entity).State = EntityState.Modified;
        }
        _database.SaveChanges();
    }
