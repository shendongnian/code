    public class AttributeList
    {
        public int Index { get; set; }
        public int Value { get; set; }
    }
    public class LifeTimeStat
    {
        public int Index { get; set; }
        public int Value { get; set; }
    }
    public class StatsList
    {
        public int Index { get; set; }
        public int Value { get; set; }
    }
    public class ItemData
    {
        public int AssetId { get; set; }
        public int Assists { get; set; }
        public List<AttributeList> AttributeList { get; set; }
        public int CardSubTypeId { get; set; }
        public int Contract { get; set; }
        public int DiscardValue { get; set; }
        public int Fitness { get; set; }
        public string Formation { get; set; }
        public object Id { get; set; }
        public int InjuryGames { get; set; }
        public string InjuryType { get; set; }
        public string ItemState { get; set; }
        public string ItemType { get; set; }
        public int LastSalePrice { get; set; }
        public int LeagueId { get; set; }
        public int LifeTimeAssists { get; set; }
        public List<LifeTimeStat> LifeTimeStats { get; set; }
        public int LoyaltyBonus { get; set; }
        public int Morale { get; set; }
        public int Owners { get; set; }
        public int PlayStyle { get; set; }
        public string PreferredPosition { get; set; }
        public int RareFlag { get; set; }
        public int Rating { get; set; }
        public int ResourceId { get; set; }
        public List<StatsList> StatsList { get; set; }
        public int Suspension { get; set; }
        public int TeamId { get; set; }
        public string Timestamp { get; set; }
        public int Training { get; set; }
        public bool Untradeable { get; set; }
        public int Pile { get; set; }
    }
    public class RootObject
    {
        public string BidState { get; set; }
        public int BuyNowPrice { get; set; }
        public int CurrentBid { get; set; }
        public int Expires { get; set; }
        public ItemData ItemData { get; set; }
        public int Offers { get; set; }
        public string SellerEstablished { get; set; }
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public int StartingBid { get; set; }
        public object TradeId { get; set; }
        public string TradeState { get; set; }
        public object Watched { get; set; }
    }
