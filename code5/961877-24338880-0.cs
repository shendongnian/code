    public class TradingPair
    {
        public string result { get; set; }
        public decimal last { get; set; }
        public decimal high { get; set; }
        public decimal low { get; set; }
        public decimal avg { get; set; }
        public decimal sell { get; set; }
        public decimal buy { get; set; }
        [JsonExtensionData]
        private Dictionary<string, object> vols { get; set; }
    }
