    public class Auction
    {
        public int lngAuctionId { get; set; }
        public string txtTitle { get; set; }
    
        public virtual Collection<Bid> Bids { get; private set; }
    
        public Auction()
        {
            Bids = new Collection<Bid>();
        }
    }
