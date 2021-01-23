    public class FooDb : DbContext
        {
            public FooDb()
                : base("name=DefaultConnection")
            { }
            public DbSet<BarTypeA> BarTypesA { get; set; }
            public DbSet<BarTypeB> BarTypesB { get; set; }
            public DbSet<BarTypeC> BarTypesC { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Foo>()
                .Map<LookupType>(m => m.Requires("xyx" + "FooType").HasValue("L"))
                .Map<BarTypeA>(m => m.Requires("xyx" + "LookupType").HasValue("A"))
                .Map<BarTypeB>(m => m.Requires("xyx" + "LookupType").HasValue("B"))
                .Map<BarTypeC>(m => m.Requires("xyx" + "LookupType").HasValue("C"));
            }
        }
