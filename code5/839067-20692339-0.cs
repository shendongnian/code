    namespace YourProject.Models
    {
        public class YourDataContext : DbContext
        {
            public DbSet<Organization> Organizations { get; set; }
    
            public override int SaveChanges()
            {
                var changedEntities = ChangeTracker.Entries();
    
                foreach (var changedEntity in changedEntities)
                {
                    if (!(changedEntity.Entity is Entity)) continue;
                    var entity = (Entity)changedEntity.Entity;
    
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.OnBeforeInsert();
                            break;
    
                        case EntityState.Modified:
                            entity.OnBeforeUpdate();
                            break;
    
                    }
                }
    
                return base.SaveChanges();
            }
        }
    
        public abstract class Entity
        {
            public virtual void OnBeforeInsert() { }
            public virtual void OnBeforeUpdate() { }
        }
    }
