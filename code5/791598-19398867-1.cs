    public override int SaveChanges()
    {
       foreach (var entry in ChangeTracker.Entries()
                 .Where(p => p.State == EntityState.Deleted 
                 && p.Entity is ModelBase))//I have a base class for entities with a single 
                                           //"ID" property - all my entities derive from this
        CustomDelete(entry);
    
        return base.SaveChanges();
    }
    
    private void CustomDelete(DbEntityEntry entry)
    {
        var e = entry.Entity as ModelBase;
        string tableName = GetTableName(e.GetType());
        string sql = String.Format(@"INSERT INTO archive.{0} SELECT * FROM {0} WHERE ID = @id; 
                                     DELETE FROM {0} WHERE ID = @id", tableName);
        Database.ExecuteSqlCommand(
                 sql
                 , new SqlParameter("id", e.ID));
        entry.State = EntityState.Detached;
    }
