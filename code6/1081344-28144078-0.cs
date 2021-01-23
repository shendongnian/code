        public class Realm
        {
            public string name { get; set; }
            public string slug { get; set; }
        }
        public class Auction
        {
            public int auc { get; set; }
            public int item { get; set; }
            public string owner { get; set; }
            public string ownerRealm { get; set; }
            public int bid { get; set; }
            public int buyout { get; set; }
            public int quantity { get; set; }
            public string timeLeft { get; set; }
            public int rand { get; set; }
            public int seed { get; set; }
            public int context { get; set; }
        }
        public class Auctions
        {
            public List<Auction> auctions { get; set; }
        }
        public class RootObject
        {
            public Realm realm { get; set; }
            public Auctions auctions { get; set; }
        }
    
