    public class AuctionModel
    {
        [Key]
        public int Id { get; set; }
    
        [Required, ForeignKey("Seller"), Column(Order = 2)]
        public string SellerUsername { get; set; }
        
        [Required, ForeignKey("Seller"), Column(Order = 3)]
        public string SellerSiteName { get; set; }
    
        [ForeignKey("CurrentWinner"), Column(Order = 4)]
        public string CurrentWinnerUsername { get; set; }
    
        [ForeignKey("CurrentWinner"), Column(Order = 5)]
        public string CurrentWinnerSiteName { get; set; }
    
        public virtual UserModel Seller { get; set; }
        public virtual UserModel CurrentWinner { get; set; }
    }
