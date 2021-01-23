    public class User
    {
        public int Id { get; set; }
        public int? LoyaltyUserId { get; set; }
        public virtual LoyaltyUser LoyaltyUser { get; set; }
    }
    public class LoyaltyUser
    {
        public int Id { get; set; }
        public virtual User MainUser { get; set; }
    }
            modelBuilder.Entity<User>()
                .HasOptional(x => x.LoyaltyUser)
                .WithOptionalDependent(c => c.MainUser)
                .WillCascadeOnDelete(false);
