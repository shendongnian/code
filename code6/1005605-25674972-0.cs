    public class Person
    {
            public int? HomeAddressID { get; set; }
            private Address _homeAddress;
            public Address HomeAddress
            {
                get { return _homeAddress; }
                set
                {
                    _homeAddress= value;
                    HomeAddressID = value != null ? (int?)value.HomeAddressID : null;
                }
            }
    }
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        HasOptional(a => a.HomeAddress).WithMany().HasForeignKey(p => p.HomeAddressID);
    }
