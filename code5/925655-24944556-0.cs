    public class Person
    {
        public Guid Id { get; set; }
        public string Designation { get; set; }
        public virtual PersonDetail Detail { get; set; }
        public virtual Person AggregatedOn { get; set; }
        protected ICollection<Person> aggregationOf;
        public virtual ICollection<Person> AggregationOf
        {
            get { return aggregationOf ?? (aggregationOf = new HashSet<Person>()); }
            set { aggregationOf = value; }
        }
    }
    public abstract class PersonDetail
    {
        public Guid Id { get; set; }
        public virtual Person Personne { get; set; }
    }
    public class Corporation : PersonDetail
    {
        public string Label { get; set; }
    }
    public class HumanBeing : PersonDetail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class ReferentialContext : DbContext
    {
        public ReferentialContext()
            : base("ReferentialContext")
        {
        }
        public ReferentialContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
        public DbSet<Person> Personnes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Types().Configure(t => t.ToTable(t.ClrType.Name.ToUpper()));
            modelBuilder.Properties().Configure(p => p.HasColumnName(p.ClrPropertyInfo.Name.ToUpper()));
            modelBuilder.Configurations.Add(new PersonConfiguration());
            modelBuilder.Configurations.Add(new PersonDetailConfiguration());
        }
    }
    class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            this.HasMany(p => p.AggregationOf)
                .WithOptional(p => p.AggregatedOn);
        }
    }
    class PersonDetailConfiguration : EntityTypeConfiguration<PersonDetail>
    {
        public PersonDetailConfiguration()
        {
            this.Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.HasRequired(p => p.Personne)
                .WithRequiredDependent(p => p.Detail);
        }
    }
