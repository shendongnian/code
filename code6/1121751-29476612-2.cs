    public class GlobalVars
    {
        static StockPrices _stockPrices = new StockPrices();
        public static StockPrices StockPrices 
        {
            get
            {
                return _stockPrices ;
            }
        }
    }
    public class StockPrices
    {
        Dictionary<int, StockPrice> InternalDictionary = new Dictionary<int, StockPrice>();
        public StockPrice this[int index]
        {
            get
            {
                StockPrice stockPrice = null;
                
                if (index > -1)
                {
                    InternalDictionary.TryGetValue(index, out stockPrice);
                }
                return stockPrice;
            }
        }
        public void Add(StockPrice stockPrice)
        {
            int index = InternalDictionary.Keys.Max() + 1;
            InternalDictionary.Add(index, stockPrice);
        }
    }
