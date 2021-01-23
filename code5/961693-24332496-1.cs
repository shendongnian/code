    Lazy<IEnumerable<Discount>> discounts = new Lazy<IEnumerable<Discount>>(new DiscountCollection());
    
    public IEnumerable<Discount> GetDiscounts()
    {
       return discounts.Value;
    }
