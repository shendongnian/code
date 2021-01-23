    public class Lot
    {
        public int LotId { get; set; }
        public string Description { get; set; }
        public virtual Product Product { get; set; }
        [InverseProperty("SelledLots")]
        public virtual ApplicationUser Owner { get; set; }
        [InverseProperty("BuyedLots")]
        public virtual ApplicationUser CurrentCustomer { get; set; }
        [InverseProperty("ParticipatedLots")]
        public virtual ICollection<ApplicationUser> AllCustomers { get; set; }
        public virtual AuctionDates AuctionDates { get; set; }
        public  virtual AuctionPrices AuctionPrices { get; set; }
        public virtual State State { get; set; }
        public virtual ProductImages Images { get; set; }
    }
