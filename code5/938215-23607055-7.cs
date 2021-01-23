    public class MyContext : DbContext
    {
        public DbSet<Transaction> Trans { get; set; }
        public MyContext () : base()
        {
        }
        public override int SaveChanges()
        {
            var changedEntities = ChangeTracker.Entries();
            foreach (var changedEntity in changedEntities)
            {
                var entity = (Entity)changedEntity.Entity;
                entity.OnSave();
            }
            return base.SaveChanges();
        }
    }
