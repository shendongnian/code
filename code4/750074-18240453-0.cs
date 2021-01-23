    public class PIIUser
    {
        ...
        public int? LoyaltyUserDetailId { get; set; }
        [ForeignKey("LoyaltyUserDetailId")]
        public LoyaltyUserDetail LoyaltyUserDetail { get; set; }
        ...
    }
