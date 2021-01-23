namespace OneToOne
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MyContext())
            {
                var person = new Person();
                db.Persons.Add(person);
                db.SaveChanges();
                person = db.Persons.Include("RegistrationAddress").Include("ResidenceAddress").FirstOrDefault();
                var address = new AdressInfo { Person = person };
                person.RegistrationAddress = address;
                person.ResidenceAddress = address;
                db.Persons.Attach(person);
                db.SaveChanges();
            }
        }
    }
    public class MyContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<AdressInfo> AdressInfos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new AdressInfoConfig());
            modelBuilder.Configurations.Add(new PersonConfig());
        }
    }
    public class PersonConfig : EntityTypeConfiguration<Person>
    {
        public PersonConfig()
        {
            this.ToTable("Persons");
            this.HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
    
    public class Person
    {
        public int Id { get; set; }
        public virtual AdressInfo RegistrationAddress { get; set; }
        public virtual AdressInfo ResidenceAddress { get; set; }
    }
    
    public class AdressInfo
    {
        public int Id { get; set; }
        public virtual Person Person { get; set; }
    }
    public class AdressInfoConfig : EntityTypeConfiguration<AdressInfo>
    {
        public AdressInfoConfig()
        {
            this.ToTable("AdressInfos");
            this.HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasOptional(x => x.Person).WithOptionalDependent(x => x.RegistrationAddress).WillCascadeOnDelete(false);
            this.HasOptional(x => x.Person).WithOptionalDependent(x => x.ResidenceAddress).WillCascadeOnDelete(false);
        }
    }
}
