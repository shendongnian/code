    class StockGroup
    {
        public List<Stock> Stocks { get; private set; }
        
        public string Id { get; private set; }
        public double TotalPrice { get; private set; }
        public double AveragePrice { get; private set; }
        public double Qty { get; private set; }
        
        public StockGroup(string id, IEnumerable<Stock> stocks)
        {
            this.Id = id;
            this.Stocks = stocks.ToList();
            foreach (var stock in this.Stocks)
            {
                this.Qty += stock.Qty;
                this.TotalPrice += stock.Price * stock.Qty;
            }
            this.AveragePrice = this.TotalPrice / this.Qty;
        }
    }
    // use like
    var groups =
             _investments.GroupBy(x => x.Id).Select(x => new StockGroup(x.Key, x));
