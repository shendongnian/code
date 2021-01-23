    public class InsuranceContext : DbContext
        {
            public DbSet<Person> People { get; set; }
            public DbSet<AddressInfo> AddressInfos { get; set; }
            public DbSet<PassportInfo> PassportInfos { get; set; }
            public DbSet<LocalityType> LocalityTypes { get; set; }
            public DbSet<StreetType> StreetTypes { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Configurations.Add(new AddressInfoConfig());
                modelBuilder.Configurations.Add(new PersonConfig());
                modelBuilder.Configurations.Add(new PassportInfoConfig());
            }
        }
    
        public class PersonConfig : EntityTypeConfiguration<Person>
        {
            public PersonConfig()
            {
                this.ToTable("People");
                this.HasKey(x => x.Id)
                    .Property(x => x.Id)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            }
        }
    
        public class AddressInfoConfig : EntityTypeConfiguration<AddressInfo>
        {
            public AddressInfoConfig()
            {
                this.ToTable("AddressInfos");
                this.HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                this.HasOptional(x => x.Person).WithOptionalDependent(x => x.RegistrationAddress).WillCascadeOnDelete(false);
                this.HasOptional(x => x.Person).WithOptionalDependent(x => x.ResidenseAddress).WillCascadeOnDelete(false);
            }
        }
    
        public class PassportInfoConfig : EntityTypeConfiguration<PassportInfo>
        {
            public PassportInfoConfig()
            {
                this.ToTable("PassportInfos");
                this.HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                this.HasOptional(x => x.Person).WithOptionalDependent(x => x.Passport).WillCascadeOnDelete(false);
                this.HasOptional(x => x.Person).WithOptionalDependent(x => x.DriverLicense).WillCascadeOnDelete(false);
                this.HasOptional(x => x.Person).WithOptionalDependent(x => x.PensionCertificate).WillCascadeOnDelete(false);
            }
        }
