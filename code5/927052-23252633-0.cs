    public class YourDbContext{
    public override int SaveChanges()
    {
         foreach (var entry in this.ChangeTracker.Entries())
         {
                var caseEntry = entry.Entity as @case;
                if (caseEntry != null)
                {
                 
                    if (entry.State == EntityState.Added)
                    {
                        caseEntry.Id = GenerateId();                       
                    }
                  
                }
         }
         return base.SaveChanges();
    }
    }
