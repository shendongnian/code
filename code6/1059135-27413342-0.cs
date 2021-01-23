    public decimal Amount
    {
        if (Products == null) { return 0; }
        get { return Products.Price * Qty; }
    }
