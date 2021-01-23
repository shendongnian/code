    private double _salePrice;
    public double SalePrice
    {
        get { return _salePrice; }
        set
        {
            // only set _salePrice if it's less than
            // or equal to Price
            if(value <= Price)
                _salePrice = value;
        }
    }
