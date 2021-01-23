    public class LotteryCartItem
    {
    
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        [Key, Column(Order=0), ForeignKey("Class")]
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }
    
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        [Key, Column(Order=1), ForeignKey("LotteryCart")]
        public int LotteryCartId { get; set; }
        public virtual LotteryCart LotteryCart { get; set; }
    
        public int BidWeight { get; set; }
        public int order { get; set; }
        public string type { get; set; }
    }
