        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Person");
            });
            modelBuilder.Entity<PersonLegal>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("PersonLegal");
            });
            modelBuilder.Entity<PersonPhysical>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("PersonPhysical");
            });
            modelBuilder.Entity<Person>()
                .Property(t => t.Id)
                .HasColumnName("PERSONID");
            modelBuilder.Entity<PersonLegal>()
                .Property(t => t.Id)
                .HasColumnName("PERSONLEGAL");
            modelBuilder.Entity<PersonPhysical>()
                .Property(t => t.Id)
                .HasColumnName("PERSONPHYSICAL");
            base.OnModelCreating(modelBuilder);
        }
