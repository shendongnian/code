    public class MyContext : DbContext
    {
    
     public int SaveChanges(int userId)
     {
    	// Get all Added/Deleted/Modified entities (not Unmodified or Detached)
    	foreach (var ent in this.ChangeTracker.Entries().Where(p => p.State ==  EntityState.Added 
    	|| p.State == EntityState.Deleted || p.State == EntityState.Modified))
    	{
    
    		foreach (AuditLog x in GetAuditRecordsForChange(ent, userId))
    		{
    			this.AuditLogs.Add(x);
    		}
    	}
    	return base.SaveChanges();
      }
    ...
