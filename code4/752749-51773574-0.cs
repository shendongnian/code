    public class ContactConfiguration : EntityTypeConfiguration<Contact>
    {
        public ContactConfiguration()
        {
            //props for PersonalAddress instance of Address complex type class
            this.Property(t => t.PersonalAddress.Address.Street)
                .HasColumnName("PersonalAddressStreet");
            this.Property(t => t.PersonalAddress.Address.PostalCode)
                .HasColumnName("PersonalAddressPostalCode");
            this.Property(t => t.PersonalAddress.Address.City)
                .HasColumnName("PersonalAddressCity");
            //props for BusinessAddress instance of Address complex type class
            this.Property(t => t.BusinessAddress.Address.Street)
                .HasColumnName("BusinessAddressStreet");
            this.Property(t => t.BusinessAddress.Address.PostalCode)
                .HasColumnName("BusinessAddressPostalCode");
            this.Property(t => t.BusinessAddress.Address.City)
                .HasColumnName("BusinessAddressCity");
        }
    }
