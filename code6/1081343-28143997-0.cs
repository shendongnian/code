    public class WoWAuctionResponse {
        public WoWRealmInfo Realm {get; set;}
        public WoWAuctionsBody Auctions {get; set;}
    }
    
    public class WoWAuctionsBody {
       public List<WoWAuction> Auctions {get; set;}
    }
    
    // ...
    
    JsonConvert.DeserializeObject<WoWAuctionResponse>(json);
