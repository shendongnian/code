    public class MyContext : DbContext
    {
        static MyContext()
        {
            Database.SetInitializer<MyContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PatientMap());
        }
    }
