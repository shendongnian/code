    public class JSONResponse
    {
        public number number{ get; set; }
        public Inf info{ get; set; }
    }
    public class number
    {
        public int reason { get; set; }
        public string about { get; set; }
    }
    public class Inf
    {
        public int campaignId { get; set; }
        public string programCode { get; set; }
    }
