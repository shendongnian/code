        public class AppContext : DbContext
        {
            public DbSet<Person> People { get; set; }
            public DbSet<Store> Stores { get; set; }
            public DbSet<Address> Addresses { get; set; }
        }
        public class Person
        {
            public Person()
            {
                Addresses = new HashSet<PersonAddress>();
            }
            public int Id { get; set; }
            public string Name { get; set; }
            public virtual ICollection<PersonAddress> Addresses { get; set; }
        }
        public class Store
        {
            public Store()
            {
               Addresses = new HashSet<StoreAddress>();
            }
            public int Id { get; set; }
            public string StoreName { get; set; }
            public virtual ICollection<StoreAddress> Addresses { get; set; }
        }
        public abstract class Address
        {
            public int Id { get; set; }
            public string AddressInformation { get; set; }
        }
        public class PersonAddress : Address
        {
            public string PersonAddressInformation { get; set; }
        }
        public class StoreAddress : Address
        {
            public string StoreAddressInformation { get; set; }
        }
