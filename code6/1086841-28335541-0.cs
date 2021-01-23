    public bool IsDiscountValid(ProductPrice pp)
    {
        return pp.SalePrice <= pp.RegularPrice;
    }
    public decimal CalculateDiscount(ProductPrice pp)
    {
       return (pp.RegularPrice - pp.SalePrice) / pp.RegularPrice;
    }
