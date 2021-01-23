    public int CalculatePrice(string parameters)
    {
        var price = CalculatePriceWithoutVAT(parameters);
    
        if (IsVATNeeded(parameters))
        {
            price = ApplyVAT(price);
        }
    
        return price;
    }
