    using MyApp.Core.Entities.Directory;
    using MyApp.Data.Mapping;
    using System.Data.Entity;
    
    namespace MyApp.Data
    {
        [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
        public class MyContext : DbContext
        {
            public MyContext() : this("MyDB") { }
            public MyContext(string connStringName) : base(connStringName) {}
            static MyContext ()
            {
                // static constructors are guaranteed to only fire once per application.
                // I do this here instead of App_Start so I can avoid including EF
                // in my MVC project (I use UnitOfWork/Repository pattern instead)
                DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
            }
    
            public DbSet<Country> Countries { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                // I have an abstract base EntityMap class that maps Ids for my entities.
                // It is used as the base for all my class mappings
                modelBuilder.Configurations.AddFromAssembly(typeof(EntityMap<>).Assembly);
                base.OnModelCreating(modelBuilder);
            }
        }
    }
