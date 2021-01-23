    [DbConfigurationType(typeof(CustomDbConfiguration))]
    public class ZipCodeContext : DbContext
    {
        public DbSet<ZipCode> ZipCodes { get; set; }
    }
    [DbConfigurationType(typeof(CustomDbConfiguration))]
    public class MyContext : DbContext
    {
        public DbSet<MyClass> MyClasses { get; set; }
    }
