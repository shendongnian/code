    [DataContract]
    public class Person
    {
        [Key]
        [DataMember]
        public int PersonId { get; set; }
        [DataMember]
        public string Name { get; set; }
        // No [DataMember].
        public Phone Phone { get; set; }
    }
    [DataContract]
    public class Phone
    {
        [DataMember]
        public int PhoneId { get; set; }
        [Key]
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
            modelBuilder.Entity<Phone>().HasRequired(q => q.Person).WithOptional(q => q.Phone);
        }
    }
