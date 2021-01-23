    List<StockEntry> _stocks = new List<StockEntry>(); // Make it a class variable, not a method variable.           
    protected override void Initialize()
    {                       
        //5min price bars
        _stocks.Add(new StockEntry { Name = "ABC", Period = PeriodType.Minute, Value = 5, Count = 0 } );
        ....
    }
