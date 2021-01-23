    public class OrderBook
    {
        public double TimeStamp { get; set; }
        public List<List<decimal>> Bids { get; set; }
        public List<List<decimal>> Asks { get; set; }
    }
