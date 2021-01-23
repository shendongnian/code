    internal class StockItem
    {
        private static int _lastStockNumber = 10000;
        public decimal CostPrice { get; private set; }
        public string Description { get; private set; }
        public int StockNumber { get; private set; }
        public static int LastStockNumber
        {
            get { return _lastStockNumber; }
        }
        // Constructor not allowing for setting of Stock Number
        public StockItem(string description, decimal costPrice)
        {
            Interlocked.Increment(ref _lastStockNumber);
            this.CostPrice = costPrice;
            this.Description = description;
        }
        // Constructor allowing for direct setting of stockNumber
        public StockItem(int stockNumber, string description, decimal costPrice)
        {
            this.StockNumber = stockNumber;
            this.CostPrice = costPrice;
            this.Description = description;
        }
    }
