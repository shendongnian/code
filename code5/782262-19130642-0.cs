    public CarEngine(string description, int costPrice, int weight, string engineNumber)
        : base(description, costPrice, weight)
    {
        EngineNumber = engineNumber;
    }
    //this is in the heavystockitem class//
    public HeavyStockItem(string description, int costPrice, int weight)
        : base(description, costPrice)
    {
        Weight = weight;
    }
    // this is in the stockitem class //
    public StockItem(string description, int costPrice)
    {
        LastStockNumber++;
        StockNumber = LastStockNumber;
        Description = description;
        CostPrice = costPrice;
    }
