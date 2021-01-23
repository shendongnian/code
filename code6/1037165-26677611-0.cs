    var parsedResponse = JsonConvert.DeserializeObject<CouponLines>(jsonResponse);
    //...
    
    public class CouponLines
    {
        public List<CouponLine> order { get; set; }
    }
