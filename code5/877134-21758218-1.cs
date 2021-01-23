    [Route("/Merchants", "POST")]
    public class MerchantsRequest
    {
        public Dictionary<int, Merchant> MainMerchants { get; set; }
    }
