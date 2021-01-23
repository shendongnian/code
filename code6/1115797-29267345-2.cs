    private decimal _totalAdjusted;
    
    public ThisIsMyConstructor(){
        _totalAdjusted = ComputeHours();
    }
    
    public decimal TotalAdjusted
    {
        set { _totalAdjusted = value;  }
        get { return _totalAdjusted ; }
    }
