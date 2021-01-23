    [DataContract]
    public class Person
    {
        [Key]
        [DataMember]
        public int PersonId { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
    [DataContract]
    public class Phone
    {
        [Key]
        [DataMember]
        public int PhoneId { get; set; }
        [DataMember]
        public int PersonId { get; set; }
        // No [DataMember] here.
        [ForeignKey("PersonId")]
        public Person Person { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
    }
    public class MyContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public MyContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // If I had a Phones collection on Person, I could use the other override
            // of WithMany.
            modelBuilder.Entity<Phone>().HasRequired(q => q.Person).WithMany();
        }
    }
