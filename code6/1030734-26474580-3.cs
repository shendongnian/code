    public partial class MyDataContext : DbContext, IMyDataContext
    {
        static HealthDataContext()
        {
          Database.SetInitializer<HealthDataContext>(null);
        }
    
        public IDbSet<MyClass> MyClasses { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          modelBuilder.Configurations.Add(new MyClassMap());
    
        }
    
        public override int SaveChanges()
        {
          var changeSet = ChangeTracker.Entries();
    
          if (changeSet != null)
          {
            foreach (var entry in changeSet.Where(c => c.State == EntityState.Deleted || c.State == EntityState.Added || c.State == EntityState.Modified))
            {
    
              switch (entry.State)
              {
                case EntityState.Added:
                  if (entry.Entity.GetType().GetProperty("createddt") != null)
                  {
                    entry.Entity.GetType().GetProperty("createddt").SetValue(entry.Entity, new Health.Core.Helpers.RealClock().UtcNow);
                  }
                  
                  break;
                case EntityState.Deleted:
                  break;
                case EntityState.Detached:
                  break;
                case EntityState.Modified:
                  if (entry.Entity.GetType().GetProperty("updateddt") != null)
                  {
                    entry.Entity.GetType().GetProperty("updateddt").SetValue(entry.Entity, new Health.Core.Helpers.RealClock().UtcNow);
                  }
                  
                  break;
                case EntityState.Unchanged:
                  break;
                default:
                  break;
              }
    
            }
          }
          return base.SaveChanges();
        }
    }
