    [Alias("Purchase")]
    public class CustomPurchase : QueryBase<Purchase>
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public string SellerName { get; set; }
        public string BuyerName { get; set; }
    }
    
    public class QueryPurchase : QueryBase<Purchase>
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public List<int> BuyerIds { get; set; }
        public List<int> SellerIds { get; set; }
    }
