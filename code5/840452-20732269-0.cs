    public class MyContext : DbContext
    {
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<YourEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                   // do something with entry.Entity
                }
                if (entry.State == EntityState.Modified)
                {
                   // do something with entry.Entity
                }
                // etc.
            }
            return base.SaveChanges();
        }
    }
