    public class Pair
    {
        public Tuple<string, string> names { get; set; }
        public Tuple<decimal, decimal> vols { get; set; }
        
        // common properties
        public bool result { get; set; }
        public decimal last { get; set; }
        public decimal high { get; set; }
        public decimal low { get; set; }
        public decimal avg { get; set; }
        public decimal sell { get; set; }
        public decimal buy { get; set; }
    }
