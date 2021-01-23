    public class MyDbContext : DbContext
    {
        public event Action<MyDbContext> SavingChanges = _ => { };
        public override int SaveChanges()
        {
            // Notify objects that want to know, that we are gonna save some stuff
            this.SavingChanges(this);
            // Call the actual SaveChanges method to apply the changes to the database
            return base.SaveChanges();
        }
    }
