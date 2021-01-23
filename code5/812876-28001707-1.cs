    public class OwnerConfiguration : EntityTypeConfiguration<Owner>
    {
        public OwnerConfiguration()
        {
            HasRequired(x => x.Animals)
                .WithMany(x => x.Owners)  // Or, just .WithMany()
                .HasForeignKey(x => x.Pet1ID);
        }
    }
