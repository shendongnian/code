    public abstract class PersonConfiguration : EntityMappingConfiguration<Person>
    {
        public override void Map(EntityTypeBuilder<Person> b)
        {
            b.ToTable("Person", "HumanResources")
                .HasKey(p => p.PersonID);
            b.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
            b.Property(p => p.MiddleName).HasMaxLength(50);
            b.Property(p => p.LastName).HasMaxLength(50).IsRequired();
        }
    }
