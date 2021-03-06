    public class PIIUser
    {
        public int Id { get; set; }    
        public LoyaltyUserDetail LoyaltyUserDetail { get; set; }
    }
    
    public class LoyaltyUserDetail
    {
        public int Id { get; set; }
        public double? AvailablePoints { get; set; }    
        public PIIUser PIIUser { get; set; }
    }
    
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<LoyaltyUserDetail>()
      .HasRequired(lu => lu.PIIUser )
      .WithOptional(pi => pi.LoyaltyUserDetail );
    }
