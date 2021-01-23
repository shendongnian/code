    public sealed class XyzConfiguration : EntityTypeConfiguration<Xyz>
    {
        public XyzConfiguration()
        {
            // Your code.
            this.HasOptional(x => x.MyAddress)      // Your Xyz has an optional Address
                .WithMany()                         // Address may be owned by many Xyz objects
                .HasForeignKey(x => x.AddressId);   // Use this foreign key.
        }
    }
