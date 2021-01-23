    public class YourContext : DbContext
    {
        //...
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Contacts)
                .WithRequired(c => c.Person)
                .Map(f => f.MapKey("Person_Id"));
        }
    }
