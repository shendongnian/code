    public Guid AuctionItem_Auction_Id 
            {
                get { return AuctionItem.Auction_Id; }
                set { AuctionItem.Auction_Id = value; }
            }
     
        [ForeignKey("AuctionItem_Auction_Id")]
        public virtual Auction Auction { get; protected set; }
