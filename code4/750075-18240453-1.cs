    public class LoyaltyUserDetail
    {
        ...
        public int PIIUserId { get; set; }
        [ForeignKey("PIIUserId")]
        public PIIUser PIIUser { get; set; }
        ...
    }
