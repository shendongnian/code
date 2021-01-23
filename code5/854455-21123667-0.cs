    ...
    public double TotalValue
    {
        get
        {
             return Math.Round (ProductCount * PriceBrutto, 2, MidpointRounding.AwayFromZero );
        }
    }
    private int productCount = 0;
    public int ProductCount
    {
        get
        {
            return productCount;
        }
        set
        {
            if( Equals( productCount, value) ) return;
            productCount = value;
            NotifyPropertyChange( "ProductCount" );
            NotifyPropertyChange( "TotalValue" );
        }
     }
    ...
