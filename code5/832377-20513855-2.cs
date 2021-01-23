    public class DbAuction : Auction
    {    
        private DbContext _context;
    
        public DbAuction(DbContext context)
        {           
            Bids = new Collection<Bid>();
            _context = context;
        }
        public override Collection<Bid> Bids 
        {
            get 
            { 
                // here ORM checks whether this auction has bids loaded
                // and if it hasn't then ORM makes database query
                // and downloads related bids
            } 
            private set { /* ... */ }
        }
    }
