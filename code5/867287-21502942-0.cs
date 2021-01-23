     public class AddressMapping : EntityTypeConfiguration<Address>
        {
            public AddressMapping()
            {
                HasKey(t => t.Address);
                Property(t => t.ZipCode); 
                // balh blah
            }
        }
