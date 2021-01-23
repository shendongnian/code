    public decimal CalculateFinalPrice
    {
        get { return CalculateOrderPrice + CalculateOrderTaxes - CalculateOrderDiscount; }
    }
    public decimal CalculateOrderPrice
    {
        get { return products.Sum(p => p.Price*p.Quantity); }
    }
    public decimal CalculateOrderTaxes
    {
        get { return products.Sum(p => p.Taxes*p.Quantity); }
    }
    public decimal CalculateOrderDiscount
    {
        get { return products.Sum(p => p.Price*p.Quantity*p.Discount); }
    }
