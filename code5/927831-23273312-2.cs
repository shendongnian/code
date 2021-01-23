    public class Result
    {
        public int RefSymbol { get; set; }
        public int SymbolFactor { get; set; }
        public int PriceCase { get; set; }
        public int RefPriceCase { get; set; }
        public int ID { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public double Bid { get; set; }
        public double Ask { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public string LastQuoteTime { get; set; }
        public int SpreadOffset { get; set; }
        public int PriceOffset { get; set; }
        public string SpreadType { get; set; }
        public bool StopTradeIfNoPrices { get; set; }
        public int StopTradeAfterSeconds { get; set; }
        public int MaxAmountPerDeal { get; set; }
        public double MinAmountPerDeal { get; set; }
        public double AskWithSpread { get; set; }
        public double BidWithSpread { get; set; }
        public int Commission { get; set; }
        public int LimitOffset { get; set; }
        public int StopOffset { get; set; }
        public int PipLocation { get; set; }
        public object Spread { get; set; }
        public bool IsUsed { get; set; }
        public bool IsDisplay { get; set; }
        public bool HasPriv { get; set; }
        public bool JustClose { get; set; }
        public bool BuyOnly { get; set; }
    }
    public class RootObject
    {
        public List<Result> result { get; set; }
    }
