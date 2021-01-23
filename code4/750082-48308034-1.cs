    public class PIIUser
    {
        // For illustration purpose I have named the PK as PIIUserId instead of Id
        // public int Id { get; set; }
        public int PIIUserId { get; set; }
    
        public int? LoyaltyUserDetailId { get; set; }
        public LoyaltyUserDetail LoyaltyUserDetail { get; set; }
    }
    
    public class LoyaltyUserDetail
    {
        // Note: You cannot define a new Primary key separately as it would create one to many relationship
        // public int LoyaltyUserDetailId { get; set; }
        // Instead you would reuse the PIIUserId from the primary table, and you can mark this as Primary Key as well as foreign key to PIIUser table
        public int PIIUserId { get; set; } 
        public double? AvailablePoints { get; set; }
    
        public int PIIUserId { get; set; }
        public PIIUser PIIUser { get; set; }
    }
