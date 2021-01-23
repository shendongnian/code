    public class AuditInfo
    {
    	[Required]
    	public DateTime CreatedDateTimeUtc { get; set; }
    	[Required]
    	public DateTime ModifiedDateTimeUtc { get; set; }
    }
    
    
    public override int SaveChanges()
    {
    	var addedEntityList = ChangeTracker.Entries().Where(x => x.Entity is AuditInfo && x.State == EntityState.Added).ToList();
    	var updatedEntityList = ChangeTracker.Entries().Where(x => x.Entity is AuditInfo && x.State == EntityState.Modified).ToList();
    
    	if (addedEntityList.Any() || updatedEntityList.Any())
    	{
    		var context = HttpContext.Current;
    		if (context == null)
    		{
    			throw new ArgumentException("Context not available");
    		}
    
    		foreach (var addedEntity in addedEntityList)
    		{
    			((AuditInfo)addedEntity.Entity).CreatedDateTimeUtc = DateTime.UtcNow;
    			((AuditInfo)addedEntity.Entity).ModifiedDateTimeUtc = DateTime.UtcNow;
    		}
    
    		foreach (var updatedEntity in updatedEntityList)
    		{
    			((AuditInfo)updatedEntity.Entity).ModifiedDateTimeUtc = DateTime.UtcNow;
    		}
    	}
    
    	return base.SaveChanges();
    }
