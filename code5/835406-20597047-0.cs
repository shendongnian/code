    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public int? FatherId { get; set; }
        public virtual Person Father { get; set; }
    
        public int? MotherId { get; set; }
        public virtual Person Mother { get; set; }
    }
    
    public class PersonTypeConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonTypeConfiguration()
        {
            HasOptional(x => x.Mother).WithMany().HasForeignKey(x => x.MotherId);
            HasOptional(x => x.Father).WithMany().HasForeignKey(x => x.Father);
        }
    }
