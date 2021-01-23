     public interface IContactRepository
        {
            IEnumerable<Contacts> GetAllContats();
            IEnumerable<Contacts> GetAllContactsWithAddress();
            int Update(object c);
        }
    
        public class ContactRepository : IContactRepository
        {
            private ContactContext _context;
    
            public ContactRepository(ContactContext context)
            {
                _context = context;
            }
    
    
            public IEnumerable<Contacts> GetAllContats()
            {
                return _context.Contacts.OrderBy(c => c.FirstName).ToList();
    
            }
    
    
            public IEnumerable<Contacts> GetAllContactsWithAddress()
            {
                return _context.Contacts
                    .Include(c => c.Address)
                    .OrderBy(c => c.FirstName).ToList();
    
            }
    
    
    
            //TODO Cambiar properties a lambda expression
            public int Update(object entity)
            {
    
                var entityProperties =  entity.GetType().GetProperties();
    
                Contacts con = ToType(entity, typeof(Contacts)) as Contacts;
              
                if (con != null)
                {
                    _context.Entry(con).State = EntityState.Modified;
                    _context.Contacts.Attach(con);
    
                    foreach (var ep in entityProperties)
                    {
                        if(ep.Name != "Id")
                            _context.Entry(con).Property(ep.Name).IsModified = true;
                    }
                }
    
    
                return _context.SaveChanges();
    
            }
    
            public static object ToType<T>( object obj, T type)
            {
                //create instance of T type object:
                object tmp = Activator.CreateInstance(Type.GetType(type.ToString()));
    
                //loop through the properties of the object you want to covert:          
                foreach (PropertyInfo pi in obj.GetType().GetProperties())
                {
                    try
                    {
                        //get the value of property and try to assign it to the property of T type object:
                        tmp.GetType().GetProperty(pi.Name).SetValue(tmp, pi.GetValue(obj, null), null);
                    }
                    catch (Exception ex)
                    {
                      //  Logging.Log.Error(ex);
                    }
                }
                //return the T type object:         
                return tmp;
            }
        
            }
    
    
     public class Contacts
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Company { get; set; }
            public string Title { get; set; }
            public Addresses Address { get; set; }
    
    
    
        }
    
    public class Addresses
        {
            [Key]
            public int Id { get; set; }
            public string AddressType { get; set; }
            public string StreetAddress { get; set; }
            public string City { get; set; }
            public State State { get; set; }
            public string PostalCode { get; set; }
           
    
        }
 
      public class ContactContext : DbContext
        {
            public DbSet<Addresses> Address { get; set; } 
            public DbSet<Contacts> Contacts { get; set; } 
            public DbSet<State> States { get; set; }
    
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
    
                var connString =
              "Server=YourServer;Database=ContactsDb;Trusted_Connection=True;MultipleActiveResultSets=true;";
    
                optionsBuilder.UseSqlServer(connString);
    
    
                base.OnConfiguring(optionsBuilder);
            }
        }
