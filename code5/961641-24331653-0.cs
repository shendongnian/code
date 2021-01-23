    [ComplexType]
    public class MagicString
    {
        public string key { get; set; }    
        public <IList> YourMagicalList { get; set; }
    }
    public class Context : DbContext
    {    
        public DbSet<SomeConfigurationObject> ConfigurationObjects { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {       
            modelBuilder.Entity<SomeConfigurationObject>().Property(u => u.MagicString.key)
                                       .HasColumnName(""YourColumn");
    
         
        }
    }
