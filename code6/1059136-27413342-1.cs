    public decimal Amount
    {        
        get
        {
            if (Products == null) { return 0; }
            return Products.Price * Qty;
        }
    }
