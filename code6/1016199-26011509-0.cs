    public decimal SalesPrice
    {
       get { return Convert.ToDecimal(_SalesPrice / 1000.0); }
       set { _SalesPrice = Convert.ToInt32(value * 1000.0); }
    }
