       [DbConfigurationType(typeof(ImgSigDbConfig))]
    class MyDbContext : DbContext
    {
        public MyDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
        public DbSet<Person> Persons { get; set; }
    }
