    public class Member
    {
        [Key]
        public int Id { get; set; }
    
        public virtual Address Address { get; set; }
    }
    public class Address
    {
        [Key]
        public int MemberId {get;set;}
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Address>()
            .HasKey(t => t.MemberID);
  
        modelBuilder
            .Entity<Member>()
            .HasRequired(t => t.Address)
            .WithRequiredPrincipal();
    }
