    public class DataContext : DbContext
        {
            public DbSet<RMA> RmaRecordList { get; set; }
            public DbSet<Customer> CustomerList { get; set; }
            public DbSet<Contact> ContactList { get; set; }
            public DbSet<Address> AddressList { get; set; }
        }
