        public DbSet<Person> Persons { get; set; }
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            var serv = PluralizationService.CreateService(new System.Globalization.CultureInfo("en-us"));
            modelBuilder.Types()
             .Configure(entity => entity.ToTable("MyPrefix_" + serv.Pluralize(entity.ClrType.Name)));
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
