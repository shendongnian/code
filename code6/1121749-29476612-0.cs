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
