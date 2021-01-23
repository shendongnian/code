    internal class StockItem
    {
        // Private to prevent externals + subclasses from mutating this
        private static int _lastStockNumber = 10000;
        // Convert to properties and private setters force subclasses to use the Ctor
        public decimal CostPrice { get; private set; }
        public string Description { get; private set; }
        public int StockNumber { get; private set; }
        // Static is now read only
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
