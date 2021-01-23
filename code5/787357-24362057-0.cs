    public int CalculatePrice(string parameters)
    {
        // Calculate result.
        var price = 5;
    
        // Are we done?
        if (!IsVATNeeded(price))
        {
            return price;
        }
    
        // Do more calculations.
        price = price * vat;
    
        return price;
    }
